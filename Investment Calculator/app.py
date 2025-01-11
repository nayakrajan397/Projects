from flask import Flask, render_template, request
import decimal
import io
import base64
# import matplotlib.pyplot as plt

class mf_calculator:
    def __init__(self):
        self.amount = 0.0
        self.monthly_period = 0
        self.lumpsum_period = 0
        self.expected_return = 0.0
    
    def retrive_user_inputs(self, amount, period, expected_return):
        self.amount = decimal.Decimal(amount)
        self.monthly_period = decimal.Decimal(float(period)) * 12
        self.lumpsum_period = decimal.Decimal(float(period))
        self.expected_return = decimal.Decimal(expected_return)

    def calculate(self):
        rate = (self.expected_return/100)/(self.monthly_period)
        rate2 = (1+rate)**self.monthly_period
        finalAmount = self.amount * ((rate2 - 1)/rate) * (1+rate)
        totalInvestment = self.amount * self.monthly_period
        gains = finalAmount - totalInvestment
        return finalAmount, totalInvestment, gains
    
    def lumpsumCalc(self):
        rate = (self.expected_return/100)
        finalAmount = self.amount * (1+rate)**(self.lumpsum_period)
        totalInvestment = self.amount
        gains = finalAmount - totalInvestment
        return finalAmount, totalInvestment, gains
    

app = Flask(__name__)

@app.route("/", methods = ["GET","POST"])

def index():
    if request.method == "POST":
        try:
            calc = mf_calculator()
            mode = request.form.get("mode")

            if mode == "SIP":
                amount = request.form.get("sipInvestmentAmount")
                period = request.form.get("sipYears")
                expected_return = request.form.get("Expected Rate of Return")
                calc.retrive_user_inputs(amount, period, expected_return)
                finalAmount, totalInvestment, gains = calc.calculate()              

            elif mode == "LumpSum":
                amount = request.form.get("lumpsumInvestmentAmount")
                period = request.form.get("lumpsumYears")
                expected_return = request.form.get("Expected Rate of Return")
                calc.retrive_user_inputs(amount, period, expected_return)
                finalAmount, totalInvestment, gains = calc.lumpsumCalc()  

            # Render the results pages
            try:
                return render_template(
                "index.html", 
                total_Investment=f"{totalInvestment:,.2f}",
                final_Amount=f"{finalAmount:,.2f}",
                gains=f"{gains:,.2f}"
                )
            except Exception as e:
                return f"Rendering Error: {e}"
        
        except Exception as e:
            return f"Error: {e}"
     
    return render_template("index.html", total_Investment=None)

if __name__ == '__main__':  
   app.run(debug=True)  