using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;

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
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/emails5.txt"))
        {
            foreach (string e in emails)
            {
                file.WriteLine(e);
            }
        }
    }

    public void writeAnswers()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:/inetpub/wwwroot/Contest/answers5.txt"))
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
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/emails5.txt"))
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
        using (System.IO.StreamReader file = new System.IO.StreamReader("C:/inetpub/wwwroot/Contest/answers5.txt"))
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
            bool correct = false;
            Contest results = new Contest();
            results.emails.Add(email.Text);
            //Correct answers are x: 439 - 496, y: 208 - 268
            //Correct answers are x: 617 - 681, y: 379 - 436
            //Correct answers are x: 557 - 586, y: 318 - 353

            var answerParsed = answer.Text.Split(',');
            var x = Convert.ToInt32(answerParsed[0]);
            var y = Convert.ToInt32(answerParsed[1]);
            if(x >= 439 && x <= 496 && y >= 208 && y <= 268)
            {
                correct = true;
            }
            if(x >= 617 && x <= 681 && y >= 379 && y <= 436)
            {
                correct = true;
            }
            if(x >= 557 && x <= 586 && y >= 318 && y <= 353)
            {
                correct = true;
            }

            if(correct)
            {
                answer.Text += " | Correct";
            }
            else
            {
                answer.Text += " | Incorrect";
            }

            results.answers.Add(answer.Text);
            results.writeAnswers();
            results.writeEmails();

            content.InnerHtml = "<h1>Thanks for participating!</h1>\n";
            content.InnerHtml += "<h1>Have a great day!</h1>\n";
        }
    }
}
