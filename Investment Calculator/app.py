from flask import Flask, render_template, request
import decimal
import io
import base64
# import matplotlib.pyplot as plt

class mf_calculator:
    def __init__(self):
        self.amount = 0.0
        self.period = 0
        self.expected_return = 0.0
    
    def retrive_user_inputs(self, amount, period, expected_return):
        self.amount = decimal.Decimal(amount)
        self.period = int(float(period) * 12)
        self.expected_return = decimal.Decimal(expected_return)

    def calculate(self):
        rate = self.expected_return / 100
        finalAmount = self.amount * ((1 + rate) ** self.period - 1) / rate
        totalInvestment = self.amount * self.period
        gains = finalAmount - totalInvestment
        return finalAmount, totalInvestment, gains
    
    # def generate_chart(self):
    #     """Create a chart for investment vs gains."""
    #     years = list(range(1, self.period + 1))
    #     cumulative_investment = [self.amount * year for year in years]
    #     cumulative_gains = [self.amount * ((1 + (self.expected_return / 100)) ** year - 1) for year in years]

    #     # Plot the chart
    #     plt.figure(figsize=(6, 4))
    #     plt.plot(years, cumulative_investment, label="Investment")
    #     plt.plot(years, cumulative_gains, label="Gains")
    #     plt.title("Investment vs Gains Over Time")
    #     plt.xlabel("Years")
    #     plt.ylabel("Amount ($)")
    #     plt.legend()
    #     plt.tight_layout()

    #     # Save chart to a string
    #     buf = io.BytesIO()
    #     plt.savefig(buf, format="png")
    #     buf.seek(0)
    #     chart = base64.b64encode(buf.getvalue()).decode('utf-8')
    #     buf.close()
    #     return chart

app = Flask(__name__)

@app.route("/", methods = ["GET","POST"])

def index():
    if request.method == "POST":
        try:
            amount = request.form.get("Monthly Investment Amount")
            period = request.form.get("Years you intend to invest")
            expected_return = request.form.get("Expected Rate of Return")

            calc = mf_calculator()
            calc.retrive_user_inputs(amount, period, expected_return)

            finalAmount, totalInvestment, gains = calc.calculate()

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