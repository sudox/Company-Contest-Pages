using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/emails6.txt"))
        {
            foreach (string e in emails)
            {
                file.WriteLine(e);
            }
        }
    }

    public void writeAnswers()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/answers6.txt"))
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
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/emails6.txt"))
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
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/answers6.txt"))
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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Contest results = new Contest();
            results.emails.Add(email.Text);

            results.answers.Add(color.Text);
            results.writeAnswers();
            results.writeEmails();

            content.InnerHtml = "<h1>Thank you for participating! Have a great day!</h1>\n";
            content.InnerHtml += "<h1>What did others choose?</h1>\n";
            content.InnerHtml += "<div style=\"float:left;\">\n";
            content.InnerHtml += "<canvas width=470 height=500 id=\"statue\"></canvas>\n";
            content.InnerHtml += "</div>\n";
            content.InnerHtml += "<div style=\"float:left;\">\n";
            content.InnerHtml += "<script>\n";
            content.InnerHtml += "function statueColor() {\n";
            content.InnerHtml += "var c = document.getElementById(\"statue\");\n";
            content.InnerHtml += "var ctx = c.getContext(\"2d\");\n";
            content.InnerHtml += "var img = document.getElementById(\"statueImg\");\n";
            content.InnerHtml += "ctx.beginPath();\n";
            content.InnerHtml += "ctx.rect(0, 0, 400, 500);\n";
            content.InnerHtml += "ctx.fillStyle = \"#\" + document.getElementById(\"answers\").options[document.getElementById(\"answers\").value-1].text\n";
            content.InnerHtml += "ctx.fill();\n";
            content.InnerHtml += "ctx.drawImage(img, 0, 0);\n";
            content.InnerHtml += "}\n";
            content.InnerHtml += "</script>\n";
            content.InnerHtml += "<label style=\"color: white; font-family: 'Lato', sans-serif;\">View Other's Answers Here: </label>\n";
            content.InnerHtml += "<select onchange=\"statueColor()\" id=\"answers\">\n";
            List<string> noDuplicates = results.answers.Distinct().ToList();
            for(int i = 0; i < noDuplicates.Count; i++)
            {
              content.InnerHtml +="<option value=\"" + (i+1) + "\">" + noDuplicates[i] + "</option>\n";
            }
            content.InnerHtml += "</select>\n";
            content.InnerHtml += "<script>\n";
            content.InnerHtml += "window.onload = statueColor;\n";
            content.InnerHtml += "</script>\n";
            content.InnerHtml += "</div>\n";
        }
    }
}
