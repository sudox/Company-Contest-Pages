using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

[Serializable]
public class Contest
{
    public List<string> emails;
    public List<string> answers;

    public Contest()
    {
        emails = new List<string>();
        answers = new List<string>();
        readEmails();
        readAnswers();
    }

    public void writeEmails()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/emails8.txt"))
        {
            foreach (string e in emails)
            {
                file.WriteLine(e);
            }
        }
    }

    public void writeAnswers()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/answers8.txt"))
        {
            foreach (string a in answers)
            {
                file.WriteLine(a);
            }
        }
    }

    public void readEmails()
    {
        string line;
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/emails8.txt"))
        {
            while ((line = file.ReadLine()) != null)
            {
                this.emails.Add(line);
            }
        }
    }

    public void readAnswers()
    {
        string line;
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/answers8.txt"))
        {
            while ((line = file.ReadLine()) != null)
            {
                this.answers.Add(line);
            }
        }
    }
}

public partial class _Default : System.Web.UI.Page
{
    public Font GetAdjustedFont(Graphics GraphicRef, string GraphicString, Font OriginalFont, int ContainerWidth, int MaxFontSize, int MinFontSize, bool SmallestOnFail)
    {
        // We utilize MeasureString which we get via a control instance           
        for (int AdjustedSize = MaxFontSize; AdjustedSize >= MinFontSize; AdjustedSize--)
        {
            System.Drawing.Font TestFont = new Font(OriginalFont.Name, AdjustedSize, OriginalFont.Style);

            // Test the string with the new size
            SizeF AdjustedSizeNew = GraphicRef.MeasureString(GraphicString, TestFont);

            if (ContainerWidth > Convert.ToInt32(AdjustedSizeNew.Width))
            {
                // Good font, return it
                return TestFont;
            }
        }

        // If you get here there was no fontsize that worked
        // return MinimumSize or Original?
        if (SmallestOnFail)
        {
            return new Font(OriginalFont.Name, MinFontSize, OriginalFont.Style);
        }
        else
        {
            return OriginalFont;
        }
    }

    protected void generateImage(int count)
    {
        string cust = caption.Text;
        System.Drawing.Bitmap bitmap;
        using (var temp = (Bitmap)System.Drawing.Image.FromFile(@"C:/inetpub/wwwroot/Contest/bubble.png"))
        {
            bitmap = new Bitmap(temp);
        }

        using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
        using (System.Drawing.Font font1 = new System.Drawing.Font("Monospace", 32, FontStyle.Regular, GraphicsUnit.Point))
        {
            Rectangle rect1 = new Rectangle(42, 52, 336, 203);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            System.Drawing.Font goodFont = GetAdjustedFont(graphics, cust, font1, rect1.Width, 32, 16, true);
            graphics.DrawString(cust + "\n-" +name.Text, goodFont, Brushes.Black, rect1, stringFormat);
        }

        bitmap.Save(@"C:/inetpub/wwwroot/contest/dogs/bubble" + count + ".jpg");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        Contest results = new Contest();
        results.emails.Add(email.Text);

        results.answers.Add(caption.Text);
        results.writeAnswers();
        results.writeEmails();

        // Generate new image
        generateImage(results.answers.Count);

        //Output content of redirect page
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:/inetpub/wwwroot/contest/thankyou.html"))
        {
            string output = @"
<html>
<head>
<link type=""text/css"" rel=""stylesheet"" href=""css/lightslider.css"" />
<script src=""https://code.jquery.com/jquery-latest.min.js""></script>
<script src=""js/lightslider.js""></script>
</head>
<body>
<h1>Thanks for playing! Check out everyone's answers!
<ul id=""light-slider"">
";
            foreach (var files in Directory.GetFiles(@"C:/inetpub/wwwroot/Contest/dogs/"))
            {
                if (Path.GetFileName(files) == "Thumbs.db")
                    continue;
                output += "<li><img src=\"dogs/" + Path.GetFileName(files) + "\"></li>\n";
            }
            output += @"</ul>
<script>
    $(document).ready(function() {
        $(""#light-slider"").lightSlider({
            item: 4,
            loop: true,
            autoWidth: true
        });
    });
</script>
</body></html>";

            file.WriteLine(output);
        }

        // Redirect to slider page
        Response.Redirect("https://promail.dorncolor.com/Contest/thankyou.html");

        
        //content.InnerHtml = "<h1>Thank you for participating! Have a great day!</h1>\n";
        //content.InnerHtml += "<h1>What did others choose?</h1>\n";
        //content.InnerHtml += "<div style=\"float:left;\">\n";
        //content.InnerHtml += "<canvas width=470 height=500 id=\"statue\"></canvas>\n";
        //content.InnerHtml += "</div>\n";
        //content.InnerHtml += "<div style=\"float:left;\">\n";
        //content.InnerHtml += "<script>\n";
        //content.InnerHtml += "function statueColor() {\n";
        //content.InnerHtml += "var c = document.getElementById(\"statue\");\n";
        //content.InnerHtml += "var ctx = c.getContext(\"2d\");\n";
        //content.InnerHtml += "var img = document.getElementById(\"statueImg\");\n";
        //content.InnerHtml += "ctx.beginPath();\n";
        //content.InnerHtml += "ctx.rect(0, 0, 400, 500);\n";
        //content.InnerHtml += "ctx.fillStyle = \"#\" + document.getElementById(\"answers\").options[document.getElementById(\"answers\").value-1].text\n";
        //content.InnerHtml += "ctx.fill();\n";
        //content.InnerHtml += "ctx.drawImage(img, 0, 0);\n";
        //content.InnerHtml += "}\n";
        //content.InnerHtml += "</script>\n";
        //content.InnerHtml += "<label style=\"color: white; font-family: 'Lato', sans-serif;\">View Other's Answers Here: </label>\n";
        //content.InnerHtml += "<select onchange=\"statueColor()\" id=\"answers\">\n";
        //List<string> noDuplicates = results.answers.Distinct().ToList();
        //for(int i = 0; i < noDuplicates.Count; i++)
        //{
        //  content.InnerHtml +="<option value=\"" + (i+1) + "\">" + noDuplicates[i] + "</option>\n";
        //}
        //content.InnerHtml += "</select>\n";
        //content.InnerHtml += "<script>\n";
        //content.InnerHtml += "window.onload = statueColor;\n";
        //content.InnerHtml += "</script>\n";
        //content.InnerHtml += "</div>\n";s
    }
}
