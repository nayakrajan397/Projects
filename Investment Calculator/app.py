from flask import Flask, render_template, request
import decimal
import io
import base64
import matplotlib.pyplot as plt

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
        rate = (self.expected_return/100)/(12)
        print('rate:', rate)
        rate2 = ((((1+rate)**self.monthly_period)-1)/rate)
        print('rate2:', rate2)
        finalAmount = (self.amount * (rate2)) * (1+rate)
        print('final amount:', finalAmount)
        totalInvestment = self.amount * self.monthly_period
        gains = finalAmount - totalInvestment
        return finalAmount, totalInvestment, gains
    
    def lumpsumCalc(self):
        rate = (self.expected_return/100)
        finalAmount = self.amount * (1+rate)**(self.lumpsum_period)
        totalInvestment = self.amount
        gains = finalAmount - totalInvestment
        return finalAmount, totalInvestment, gains

    def generate_chart(self):
        """Create a chart for investment vs gains."""
        monthlyYears = list(range(1, int(self.monthly_period) + 1))
        sip_cumulative_investment = [self.amount * year for year in monthlyYears]
        sip_cumulative_gains= [self.amount * ((1 + (self.expected_return / 100)) ** year - 1) for year in monthlyYears]
        #self.amount * ((1 + (self.expected_return / 100)) ** year - 1)

        # Plot the chart
        plt.figure(figsize=(6, 4))
        plt.plot(monthlyYears, sip_cumulative_investment, label="Investment")
        plt.plot(monthlyYears, sip_cumulative_gains, label="Gains")
        plt.title("Investment vs Gains Over Time")
        plt.xlabel("Months")
        plt.ylabel("Amount ($)")
        plt.legend()
        plt.tight_layout()

        # Save chart to a string
        buf = io.BytesIO()
        plt.savefig(buf, format="png")
        buf.seek(0)
        chart = base64.b64encode(buf.getvalue()).decode('utf-8')
        buf.close()
        return chart
    

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
                chart = calc.generate_chart()


            elif mode == "LumpSum":
                amount = request.form.get("lumpsumInvestmentAmount")
                period = request.form.get("lumpsumYears")
                expected_return = request.form.get("Expected Rate of Return")
                calc.retrive_user_inputs(amount, period, expected_return)
                finalAmount, totalInvestment, gains = calc.lumpsumCalc()
                chart = None  

            # Render the results pages
            try:
                return render_template(
                "index.html", 
                total_Investment=f"{totalInvestment:,.2f}",
                final_Amount=f"{finalAmount:,.2f}",
                gains=f"{gains:,.2f}",
                chart = chart,
                mode =mode
                )
            except Exception as e:
                return f"Rendering Error: {e}"
        
        except Exception as e:
            return f"Error: {e}"
     
    return render_template("index.html", total_Investment=None, mode = None)

if __name__ == '__main__':  
   app.run(debug=True)  