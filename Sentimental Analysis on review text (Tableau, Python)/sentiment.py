#!/usr/bin/env python
# coding: utf-8

# In[1]:


import pandas as pd

# importing nltk for NLP (Natural language Programming)
import nltk
#nltk.download('averaged_perceptron_tagger')
#nltk.download('wordnet')
#nltk.download('maxent_ne_chunker')
#nltk.download('words')

# text processing
# lowering the text
# tokenizing the text by slippting text into words and removing punctuationsa
# remove words that contain numbers
# removal of english stopwords
# POS(Part-of-speech) assigns every word a tag to determine if it is a noun, verb
# adverb or adjective. 
# lemmatize the text is to transform the text into their root form 
# (e.g. rooms -> room, slept -> sleep) 
# Wordnet is a lexicon database where a word could be defines wiith its meaning.
# Using Named Entity Recognition we grouped words together as a noun phrase
from nltk.corpus import wordnet
import string
from nltk import pos_tag, ne_chunk
from nltk.corpus import stopwords
from nltk.tokenize import WhitespaceTokenizer
from nltk.stem import WordNetLemmatizer

# Sentiment Analysis
#nltk.download('vader_lexicon')
# Vader is az lexicon i.e. dictionary of words that evaluates sentiments to a particular word
# sentiments like neg, neu, pos
# By providing vader with review text we undertsnad the polarity of the review.
from nltk.sentiment.vader import SentimentIntensityAnalyzer

# Using TextBlob we can assign a sentiment score and segment the reviews as positive or negative
from textblob import TextBlob

# Plots
import matplotlib.pyplot as plt
import seaborn as sns

#word clouds
import heapq
from wordcloud import WordCloud, STOPWORDS
from PIL import Image
import collections
import matplotlib.cm as cm
from matplotlib import rcParams
from tqdm import tqdm

# Create numerical vector of every word 
from gensim.test.utils import common_texts

# Using Doc2vec enables the machine to predict the next phrase.
# for e.g. catch the ball is a phrase in Doc2vec it first looks at the document if the doc type is 
# technology then the maschine knows instead of catch the ball a plausible solution would be catch the bug/exception.
# If it was sports then catch the ball would be perfect.
from gensim.models.doc2vec import Doc2Vec, TaggedDocument

# Extracting importance of words in the corpus
from sklearn.feature_extraction.text import TfidfVectorizer


# In[6]:


# Reading the data
yelp_df = pd.read_excel(r'Yelp.xlsx')


# In[7]:


# Drop all the uneccessary columns frolm the dataframe
yelp_df = yelp_df.drop(['business_id', 'name_x', 'date', 'user_id', 'review_id', 'stars_y', 'useful_y', 'funny_y','cool_y', 'postal_code'], axis = 1)
# Check the rows and columns of the dataframe
yelp_df.shape


# In[8]:


#sample the data for speedy computation
#This allows better results of words useful for analysing sentiments
yelp_df = yelp_df.sample(frac = 0.5, replace = False, random_state = 42)
yelp_df.shape


# In[11]:


# TEXT PRE_PROCESSING - Clean the review text data 
# Returning if the word is adj or noun or verb or adverb
def get_wordnet(pos_tag):
    if pos_tag.startswith('J'):
        return wordnet.ADJ
    elif pos_tag.startswith('V'):
        return wordnet.VERB
    elif pos_tag.startswith('N'):
        return wordnet.NOUN
    elif pos_tag.startswith('R'):
        return wordnet.ADV
    else:
        return wordnet.NOUN    

def clean_text(text):
    # lower case
    text = str(text).lower()
    # tokenize text and remove punctuations
    text = [word.strip(string.punctuation) for word in text.split(" ")]
    # remove words that contain numbers
    text = [word for word in text if not any(c.isdigit() for c in word)]
     # remove stop words
    stop = stopwords.words('english')
    text = [x for x in text if x not in stop]
    # remove empty tokens
    text = [t for t in text if len(t) > 0]
    # pos tag text
    pos_tags = pos_tag(text)
    print (pos_tags)
    # lemmatize text
    # t[0] is the first word in the pos_tags
    # get_wordnet(t[1]) is the first pos_tag i.e. is it adj, nn, v, rb
    text = [WordNetLemmatizer().lemmatize(t[0], get_wordnet(t[1])) for t in pos_tags]
    # remove words with only one letter
    text = [t for t in text if len(t) > 1]
    # join all
    text = " ".join(text)
    return(text)
    


# In[24]:


# yelp_df.head()


# In[10]:


# clean text data
yelp_df["text_clean"] = yelp_df["text"].apply(lambda x: clean_text(x))
#yelp_df.shape


# In[32]:


# Convert column text into string
yelp_df["text"] = yelp_df["text"].astype(str)

# add sentiment anaylsis columns
# Using vader lexicon of nltk package we assign sentiment to words with the help of SentimentIntensityAnalyzer  
sid = SentimentIntensityAnalyzer()

# Assigning its sentiments to sentiments column 
yelp_df["sentiments"] = yelp_df["text"].apply(lambda x: sid.polarity_scores(x))
yelp_df = pd.concat([yelp_df.drop(['sentiments'], axis=1), yelp_df['sentiments'].apply(pd.Series)], axis=1)

yelp_df.shape


# In[33]:


# In order to segregate the pos and neg reviews assigning positive and negative polarity.
yelp_df['sentiment_score'] = yelp_df['text'].map(lambda text: TextBlob(text).sentiment.polarity)

#classify sentiment into positive and negative ones
yelp_df['sentiment'] = ''
yelp_df['sentiment'][yelp_df['sentiment_score'] > 0] = 'positive'
yelp_df['sentiment'][yelp_df['sentiment_score'] <= 0] = 'negative'

yelp_df.shape


# In[34]:


# Sample data
yelp_df.head(10)


# In[35]:


# Comparison between positive and negative reviews 
plt.figure(figsize=(6,5))
ax = sns.countplot(yelp_df['sentiment'])
plt.title('Review Sentiments Distrubition')
plt.xlabel('Sentiments')
plt.ylabel('Count of reviews')


# In[36]:


# add number of characters column
yelp_df["nb_chars"] = yelp_df["text"].apply(lambda x: len(x))

# add number of words column
yelp_df["nb_words"] = yelp_df["text"].apply(lambda x: len(x.split(" ")))


# In[95]:


# For sentiment analysis to be done the document i.e. text_clean column needs to be converted into vector

# create doc2vec vector columns
docs = [TaggedDocument(doc, [i]) for i, doc in enumerate(yelp_df["text_clean"].apply(lambda x: x.split(" ")))]

# build a Doc2Vec model and train with our text data
model = Doc2Vec(docs, vector_size=5, window=2, min_count=1, workers=4)

# transform each document into a vector data
doc2vec_df = yelp_df["text_clean"].apply(lambda x: model.infer_vector(x.split(" "))).apply(pd.Series)
doc2vec_df.columns = ["doc2vec_vector_" + str(x) for x in doc2vec_df.columns]
yelp_df = pd.concat([yelp_df, doc2vec_df], axis=1)
#yelp_df
doc2vec_df


# In[38]:


# TFID inverses the documents to eveluate how important a word is to the document in the corpus

# add tf-idfs columns for every word
tf_idf = TfidfVectorizer(min_df = 10)
tf_idf_result = tf_idf.fit_transform(yelp_df["text_clean"]).toarray()
tf_idf_df = pd.DataFrame(tf_idf_result, columns = tf_idf.get_feature_names())
tf_idf_df.columns = ["word_" + str(x) for x in tf_idf_df.columns]
tf_idf_df.index = yelp_df.index
yelp_df = pd.concat([yelp_df, tf_idf_df], axis=1)
tfidf_df


# In[39]:


Yelp_pos = pd.DataFrame(yelp_df['text_clean'][yelp_df['sentiment'] == 'positive'])
Yelp_neg = pd.DataFrame(yelp_df['text_clean'][yelp_df['sentiment'] == 'negative'])


# In[ ]:


#yelp_df.to_csv(r'D:\Project\Preliminary\Yelp_Sentiment_word_transform1.csv', index = False)
#yelp_df.shape


# In[40]:


add_stopwords = ['mainly','review','vega', 'quali', 'hig', 'stop', 'ihop', 'din','pal', 'pop','kari','bite','old','saw','ate','jeff','star','try','provide','breakfas','chicago', 'loca', 'anthony', 'disappointed', 'angelinas', 'yelp', 'new', 'cold', 'hot', 'ol', 'sa', 'seem', 'eback', 'ne', 'felt', 'day', 'almost', 'normally', 'cam', 'spend', 'dog', 'fan', 'use', 'hour', 'sigh', 'big', 'windy', 'skinny', 'previously', 'seriously', 'give', 'st', 'restaur', 'buffalo', 'want', 'ngra', 'year', 'call','disappointing', 'vegas', 'city', 'house', 'yum', 'pt', 'beef', 'something', 'must', 'look', 'write', 'take', 'waste', 'different','soggy','disappoint','half','come','accu','non','aroun','ny','ok','las','anyon', 'ding','sadl','keep','yelped','lux', 'grand','columns','The','foo','I','ve','sp','kep','positive','negative', 'text_clean', 'nb_words', 'sentiment score', 'word_year', 'word_yummy', 'word_yum', 'word_yet', 'word_young', 'word_zucchni', 'word_york', 'word_you', 'word_yelp', 'word_yes', 'nb_chars', 'rows', 'sta', 'la', 'neg', 'pos', 'Th']


# Add meaningless words into stopwords
for i in range(len(add_stopwords)):
    STOPWORDS.add(add_stopwords[i])


# In[41]:


# wordcloud function

def show_wordcloud(data, title):
    wc = WordCloud(
        background_color = 'white',
        max_words = 200,
        max_font_size = 40, 
        scale = 3,
        random_state = 42,
        stopwords = set(STOPWORDS)
    ).generate(str(data))

    fig = plt.figure(1, figsize = (20, 20))
    plt.axis('off')
    if title: 
        plt.title(title, fontsize=40,color='Black')

    plt.imshow(wc)
    plt.show()
    


# In[42]:


# print wordcloud
show_wordcloud(Yelp_pos, "Word Clouds with Positive Polarity")


# In[43]:


# print wordcloud
show_wordcloud(Yelp_neg, "Word Clouds with Negative Polarity")


# In[44]:


# Perform sentiment analysis on Grand Lux Cafe 
GC_df = pd.read_csv('Grand_Lux_Cafe.csv')
GC_df = GC_df.drop(['text_length','Unnamed: 0','business_id', 'name_x', 'date', 'user_id', 'review_id', 'stars_y', 'useful_y', 'funny_y','cool_y'], axis = 1)
GC_df


# In[45]:


# clean text data
GC_df["text_clean"] = GC_df["text"].apply(lambda x: clean_text(x))
GC_df.shape


# In[47]:


# Add sentiments to review text for grand luc cafe
GC_df["GC_sentiments"] = GC_df["text"].apply(lambda x: sid.polarity_scores(x))
GC_df = pd.concat([GC_df.drop(['GC_sentiments'], axis=1), GC_df['GC_sentiments'].apply(pd.Series)], axis=1)

GC_df.shape


# In[48]:


# Assign positive and negative polarity

GC_df['GC_sentiment_score'] = GC_df['text'].map(lambda text: TextBlob(text).sentiment.polarity)

#classify sentiment into positive and negative ones
GC_df['GC_sentiment'] = ''
GC_df['GC_sentiment'][GC_df['GC_sentiment_score'] > 0] = 'positive'
GC_df['GC_sentiment'][GC_df['GC_sentiment_score'] <= 0] = 'negative'

GC_df.shape
GC_df.head(10)


# In[49]:


# Positive and Negative polarity comparison
plt.figure(figsize=(6,5))
ax = sns.countplot(yelp_df['sentiment'])
plt.title('Review Sentiments Distrubition of Grand Lux Cafe')
plt.xlabel('Sentiments')
plt.ylabel('Count of reviews')


# In[50]:


# add number of characters column
GC_df["nb_chars"] = GC_df["text"].apply(lambda x: len(x))

# add number of words column
GC_df["nb_words"] = GC_df["text"].apply(lambda x: len(x.split(" ")))


# In[51]:


# create doc2vec vector columns
documents = [TaggedDocument(doc, [i]) for i, doc in enumerate(GC_df["text_clean"].apply(lambda x: x.split(" ")))]
# train a Doc2Vec model with our text data
model = Doc2Vec(documents, vector_size=5, window=2, min_count=1, workers=4)
# transform each document into a vector data
doc2vec_df = GC_df["text_clean"].apply(lambda x: model.infer_vector(x.split(" "))).apply(pd.Series)
doc2vec_df.columns = ["doc2vec_vector_" + str(x) for x in doc2vec_df.columns]
GC_df = pd.concat([GC_df, doc2vec_df], axis=1)
GC_df


# In[52]:


# add tf-idfs columns
tfidf_GC = TfidfVectorizer(min_df = 10)
tfidf_GC_result = tfidf_GC.fit_transform(GC_df["text_clean"]).toarray()
tfidf_GC_df = pd.DataFrame(tfidf_GC_result, columns = tfidf_GC.get_feature_names())
tfidf_GC_df.columns = ["word_" + str(x) for x in tfidf_GC_df.columns]
tfidf_GC_df.index = GC_df.index
GC_df = pd.concat([GC_df, tfidf_GC_df], axis=1)
tfidf_GC_df


# In[53]:


GC_df_pos = pd.DataFrame(GC_df['text_clean'][GC_df['GC_sentiment'] == 'positive'])
GC_df_neg = pd.DataFrame(GC_df['text_clean'][GC_df['GC_sentiment'] == 'negative'])


# In[58]:


GC_df_add_stopwords = ['cheesec','fav','serv','zen','cafe', 'every', 'right', 'review','et', 'servic', 'gawd', 'nov', 'glux', 'ch', 'nice','bu', 'nalso', 'isc', 'ni', 'len', 'late', 'nbut', 'ces', 'hu', 'slow','mont', 'npacked', 'another','breakfas','chicago', 'loca', 'anthony', 'disappointed', 'angelinas', 'yelp', 'new', 'cold', 'hot', 'ol', 'sa', 'seem', 'eback', 'ne', 'felt', 'day', 'almost', 'normally', 'cam', 'spend', 'dog', 'fan', 'use', 'hour', 'sigh', 'big', 'windy', 'skinny', 'previously', 'seriously', 'give', 'st', 'restaur', 'buffalo', 'want', 'ngra', 'year', 'call','disappointing', 'vegas', 'city', 'house', 'yum', 'pt', 'beef', 'something', 'must', 'look', 'write', 'take', 'waste', 'different','soggy','disappoint','half','come','accu','non','aroun','ny','ok','las','anyon', 'ding','sadl','keep','yelped','lux', 'grand','columns','The','foo','I','ve','sp','kep','positive','negative', 'text_clean', 'nb_words', 'sentiment score', 'word_year', 'word_yummy', 'word_yum', 'word_yet', 'word_young', 'word_zucchni', 'word_york', 'word_you', 'word_yelp', 'word_yes', 'nb_chars', 'rows', 'sta', 'la', 'neg', 'pos', 'Th']


# Add meaningless words into stopwords
for i in range(len(GC_df_add_stopwords)):
    STOPWORDS.add(GC_df_add_stopwords[i])


# In[59]:


# wordcloud function

def show_wordcloud_GC(data, title):
    wc_GC = WordCloud(
        background_color = 'white',
        max_words = 200,
        max_font_size = 40, 
        scale = 3,
        random_state = 42,
        stopwords = set(STOPWORDS)
    ).generate(str(data))

    fig = plt.figure(1, figsize = (20, 20))
    plt.axis('off')
    if title: 
        plt.title(title, fontsize=40,color='Black')

    plt.imshow(wc_GC)
    plt.show()
    


# In[60]:


# print wordcloud
show_wordcloud_GC(GC_df_pos, "Word Clouds with Positive Polarity of Grand Lux Cafe")


# In[61]:


show_wordcloud_GC(GC_df_neg, "Word Clouds with Negative Polarity of Grand Lux Cafe ")


# In[72]:


# Review text Analysis for the period from 2012 - 2013 and from 2013 to 2014 to check what made the rest to loose traffic and gain it.

GC_drop = pd.read_excel(r'GC_drop_12-13.xlsx')
GC_drop = GC_drop.drop(['text_length','Unnamed: 0','business_id', 'name_x', 'date', 'user_id', 'review_id', 'stars_y', 'useful_y', 'funny_y','cool_y', 'year','month','year_month'], axis = 1)
GC_drop


# In[73]:


# clean text data
GC_drop["drop_text_clean"] = GC_df["text"].apply(lambda x: clean_text(x))
GC_drop.shape


# In[74]:


# add sentiment anaylsis columns
# Using vader lexicon of nltk package we assign sentiment to words with the help of SentimentIntensityAnalyzer  
sid = SentimentIntensityAnalyzer()
GC_drop["GC_drop_sentiments"] = GC_drop["text"].apply(lambda x: sid.polarity_scores(x))
GC_drop = pd.concat([GC_drop.drop(['GC_drop_sentiments'], axis=1), GC_drop['GC_drop_sentiments'].apply(pd.Series)], axis=1)

GC_drop.shape


# In[75]:


GC_drop['GC_drop_sentiments_score'] = GC_drop['text'].map(lambda text: TextBlob(text).sentiment.polarity)

#classify sentiment into positive and negative ones
GC_drop['GC_drop_sentiment'] = ''
GC_drop['GC_drop_sentiment'][GC_drop['GC_drop_sentiments_score'] > 0] = 'positive'
GC_drop['GC_drop_sentiment'][GC_drop['GC_drop_sentiments_score'] <= 0] = 'negative'

GC_drop.shape
GC_drop.head(10)


# In[76]:


plt.figure(figsize=(6,5))
ax = sns.countplot(GC_drop['GC_drop_sentiment'])
plt.title('Review Sentiments Distrubition of Grand Lux Cafe')
plt.xlabel('Sentiments')
plt.ylabel('Count of reviews')


# In[77]:


# create doc2vec vector columns

documents = [TaggedDocument(doc, [i]) for i, doc in enumerate(GC_drop["drop_text_clean"].apply(lambda x: x.split(" ")))]

# train a Doc2Vec model with our text data
model_1 = Doc2Vec(documents, vector_size=5, window=2, min_count=1, workers=4)

# transform each document into a vector data
doc2vec_df = GC_drop["drop_text_clean"].apply(lambda x: model_1.infer_vector(x.split(" "))).apply(pd.Series)
doc2vec_df.columns = ["doc2vec_vector_" + str(x) for x in doc2vec_df.columns]
GC_drop = pd.concat([GC_drop, doc2vec_df], axis=1)
GC_drop


# In[78]:


# add tf-idfs columns

tfidf = TfidfVectorizer(min_df = 10)
tfidf_result = tfidf.fit_transform(GC_drop["drop_text_clean"]).toarray()
tfidf_df = pd.DataFrame(tfidf_result, columns = tfidf.get_feature_names())
tfidf_df.columns = ["word_" + str(x) for x in tfidf_df.columns]
tfidf_df.index = GC_drop.index
GC_drop = pd.concat([GC_drop, tfidf_df], axis=1)
tfidf_df


# In[81]:


GC_drop_pos = pd.DataFrame(GC_drop['drop_text_clean'][GC_drop['GC_drop_sentiment'] == 'positive'])
GC_drop_neg = pd.DataFrame(GC_drop['drop_text_clean'][GC_drop['GC_drop_sentiment'] == 'negative'])


# In[90]:


GC_df_add_stopwords_1213 = ['wait','middle','order','one','good','food','degree','definitely','advise','conveniently','hearty','note','beignets','chain','version','orleans','awesome','divide','extremely','diner','nex','pretty','stuff','facto','stuff','yass','remember','delicious','past','often','favorite','recently','basically', 'end','around','actually','terrific','expect','porti','liked','lax','face','see','baz','re','nthi','nicer','da','hote','generou','venetian','etc','sister','cr','plen','cheesec','','da','fact','due','brother','husband','send','throughout','busy','fo','wai','plac','cr','drop_text_clean','cafe', 'every', 'right', 'review','et', 'servic', 'gawd', 'nov', 'glux', 'ch', 'nice','bu', 'nalso', 'isc', 'ni', 'len', 'late', 'nbut', 'ces', 'hu', 'slow','mont', 'npacked', 'another','breakfas','chicago', 'loca', 'anthony', 'disappointed', 'angelinas', 'yelp', 'new', 'cold', 'hot', 'ol', 'sa', 'seem', 'eback', 'ne', 'felt', 'day', 'almost', 'normally', 'cam', 'spend', 'dog', 'fan', 'use', 'hour', 'sigh', 'big', 'windy', 'skinny', 'previously', 'seriously', 'give', 'st', 'restaur', 'buffalo', 'want', 'ngra', 'year', 'call','disappointing', 'vegas', 'city', 'house', 'yum', 'pt', 'beef', 'something', 'must', 'look', 'write', 'take', 'waste', 'different','soggy','disappoint','half','come','accu','non','aroun','ny','ok','las','anyon', 'ding','sadl','keep','yelped','lux', 'grand','columns','The','foo','I','ve','sp','kep','positive','negative', 'text_clean', 'nb_words', 'sentiment score', 'word_year', 'word_yummy', 'word_yum', 'word_yet', 'word_young', 'word_zucchni', 'word_york', 'word_you', 'word_yelp', 'word_yes', 'nb_chars', 'rows', 'sta', 'la', 'neg', 'pos', 'Th']


# Add meaningless words into stopwords
for i in range(len(GC_df_add_stopwords_1213)):
    STOPWORDS.add(GC_df_add_stopwords_1213[i])


# In[91]:


# wordcloud function

def show_wordcloud(data, title):
    wordcloud = WordCloud(
        background_color = 'white',
        max_words = 200,
        max_font_size = 40, 
        scale = 3,
        random_state = 42,
        stopwords = set(STOPWORDS)
    ).generate(str(data))

    fig = plt.figure(1, figsize = (20, 20))
    plt.axis('off')
    if title: 
        plt.title(title, fontsize=40,color='Black')

    plt.imshow(wordcloud)
    plt.show()
    


# In[92]:


# print wordcloud
show_wordcloud(GC_drop_pos, "Positive Word Cloud in the period 2012 - 2013")


# In[93]:


show_wordcloud(GC_drop_neg, "Negative Word Cloud in the period 2012 - 2013")

