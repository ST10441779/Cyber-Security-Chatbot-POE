using CyberSecurityAwarenessChatbot.Data;
using CyberSecurityAwarenessChatbot.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace CyberSecurityAwarenessChatbot
{
    public partial class MainWindow : Window
    {

        private List<TaskItem> tasks = new();
        private List<ActivityLog> logs = new();

        private List<QuizQuestion> quizQuestions = new();

        private int currentQuestion = 0;
        private int score = 0;


        public MainWindow()
        {
            InitializeComponent();

            AddWelcomeMessage();

            LoadQuizQuestions();

            DisplayQuestion();

            AddLog("Application Started");
        }

        private void AddWelcomeMessage()
        {
            txtChat.Text =
                "Cybersecurity Awareness Chatbot\n\n" +
                "Welcome!\n\n" +
                "Ask me about:\n" +
                "- Passwords\n" +
                "- Phishing\n" +
                "- VPN\n" +
                "- Malware\n" +
                "- Privacy\n" +
                "- 2FA\n\n";
        }


        private void AddLog(string action)
        {
            logs.Add(new ActivityLog
            {
                TimeStamp = DateTime.Now,
                Action = action
            });

            RefreshLog();
        }

        private void RefreshLog()
        {
            lstActivity.ItemsSource = null;

            lstActivity.ItemsSource =
                logs.TakeLast(10).ToList();
        }

        private void BtnRefreshLog_Click(object sender, RoutedEventArgs e)
        {
            RefreshLog();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            string input = txtUserInput.Text;

            if (string.IsNullOrWhiteSpace(input))
                return;

            string response = ProcessInput(input);

            txtChat.AppendText($"You: {input}\n");
            txtChat.AppendText($"Bot: {response}\n\n");

            txtUserInput.Clear();
        }


        private string ProcessInput(string input)
        {
            input = input.ToLower();

            if (input.Contains("password"))
            {
                AddLog("Password advice requested");

                return "Use strong passwords containing uppercase letters, lowercase letters, numbers and symbols.";
            }

            if (input.Contains("phishing"))
            {
                AddLog("Phishing information requested");

                return "Phishing attacks attempt to steal personal information using fake emails or websites.";
            }

            if (input.Contains("vpn"))
            {
                AddLog("VPN information requested");

                return "A VPN encrypts your internet connection and improves online privacy.";
            }

            if (input.Contains("malware"))
            {
                AddLog("Malware information requested");

                return "Malware is malicious software designed to damage or steal data.";
            }

            if (input.Contains("privacy"))
            {
                AddLog("Privacy advice requested");

                return "Review your privacy settings regularly and avoid oversharing online.";
            }

            if (input.Contains("2fa") ||
                input.Contains("two factor") ||
                input.Contains("two-factor"))
            {
                AddLog("2FA advice requested");

                return "Two-factor authentication provides an additional layer of security.";
            }

            if (input.Contains("activity log") ||
                input.Contains("what have you done for me"))
            {
                AddLog("Activity log viewed");

                return GetRecentActivities();
            }

            if (input.Contains("quiz"))
            {
                AddLog("Quiz information requested");

                return "Open the Cyber Quiz tab to test your cybersecurity knowledge.";
            }

            if (input.Contains("task"))
            {
                AddLog("Task assistant requested");

                return "Open the Task Assistant tab to manage your cybersecurity tasks.";
            }

            return "I didn't quite understand that. Could you rephrase?";
        }


        private string GetRecentActivities()
        {
            if (logs.Count == 0)
            {
                return "No activity has been recorded yet.";
            }

            string summary = "Recent Activities:\n\n";

            foreach (var log in logs.TakeLast(5))
            {
                summary += $"{log.Action}\n";
            }

            return summary;
        }


        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            TaskItem task = new TaskItem
            {
                Title = txtTaskTitle.Text,
                Description = txtTaskDescription.Text,
                ReminderDate = dpReminder.SelectedDate,
                IsCompleted = false
            };

            tasks.Add(task);

            RefreshTasks();

            AddLog($"Task Added: {task.Title}");

            MessageBox.Show("Task successfully added.");

            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
            dpReminder.SelectedDate = null;
        }

        private void BtnComplete_Click(object sender, RoutedEventArgs e)
        {
            if (lstTasks.SelectedItem is TaskItem task)
            {
                task.IsCompleted = true;

                AddLog($"Task Completed: {task.Title}");

                RefreshTasks();

                MessageBox.Show("Task marked as completed.");
            }
        }

        private void RefreshTasks()
        {
            lstTasks.ItemsSource = null;
            lstTasks.ItemsSource = tasks;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstTasks.SelectedItem is TaskItem task)
            {
                tasks.Remove(task);

                AddLog($"Task Deleted: {task.Title}");

                RefreshTasks();

                MessageBox.Show("Task deleted.");
            }
        }

        private void LoadQuizQuestions()
        {
            quizQuestions.Add(new QuizQuestion
            {
                Question = "What is phishing?",
                Options = new string[]
                {
                    "A scam",
                    "An antivirus",
                    "A browser",
                    "A firewall"
                },
                CorrectAnswer = 0,
                Explanation = "Phishing is a scam used to steal sensitive information."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "Which password is strongest?",
                Options = new string[]
                {
                    "123456",
                    "Password",
                    "MyDog123",
                    "T@9#Lm$2!"
                },
                CorrectAnswer = 3,
                Explanation = "Strong passwords contain letters, numbers and symbols."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "Should you share your password with friends?",
                Options = new string[]
                {
                    "Yes",
                    "No",
                    "Sometimes",
                    "Only online"
                },
                CorrectAnswer = 1,
                Explanation = "Passwords should never be shared."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What does VPN stand for?",
                Options = new string[]
                {
                    "Virtual Private Network",
                    "Verified Public Network",
                    "Virtual Password Node",
                    "Visual Protection Network"
                },
                CorrectAnswer = 0,
                Explanation = "VPN stands for Virtual Private Network."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What is malware?",
                Options = new string[]
                {
                    "Safe software",
                    "Malicious software",
                    "Hardware",
                    "A website"
                },
                CorrectAnswer = 1,
                Explanation = "Malware is software designed to harm devices."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What should you do with suspicious emails?",
                Options = new string[]
                {
                    "Open them",
                    "Reply immediately",
                    "Report or delete them",
                    "Forward them"
                },
                CorrectAnswer = 2,
                Explanation = "Suspicious emails should be reported or deleted."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What is 2FA?",
                Options = new string[]
                {
                    "Two-Factor Authentication",
                    "Two File Access",
                    "Two Firewall Alerts",
                    "Double Antivirus"
                },
                CorrectAnswer = 0,
                Explanation = "2FA adds another layer of security."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "True or False: Public Wi-Fi is always safe.",
                Options = new string[]
                {
                    "True",
                    "False",
                    "Maybe",
                    "Sometimes"
                },
                CorrectAnswer = 1,
                Explanation = "Public Wi-Fi can expose your information."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What is social engineering?",
                Options = new string[]
                {
                    "Building websites",
                    "Manipulating people for information",
                    "Programming",
                    "Installing software"
                },
                CorrectAnswer = 1,
                Explanation = "Social engineering manipulates people into revealing information."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "How often should you update software?",
                Options = new string[]
                {
                    "Never",
                    "Only when broken",
                    "Regularly",
                    "Once every 5 years"
                },
                CorrectAnswer = 2,
                Explanation = "Regular updates fix security vulnerabilities."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What is ransomware?",
                Options = new string[]
                {
                    "A search engine",
                    "Software that encrypts data for ransom",
                    "A firewall",
                    "A browser"
                },
                CorrectAnswer = 1,
                Explanation = "Ransomware locks data until payment is made."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "Why should you back up your files?",
                Options = new string[]
                {
                    "To save storage",
                    "To recover data if lost",
                    "To slow your PC",
                    "No reason"
                },
                CorrectAnswer = 1,
                Explanation = "Backups help recover data after attacks or failures."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What should you check before clicking a link?",
                Options = new string[]
                {
                    "URL destination",
                    "Its colour",
                    "Its size",
                    "Nothing"
                },
                CorrectAnswer = 0,
                Explanation = "Always verify the destination URL."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "Which is a good cybersecurity habit?",
                Options = new string[]
                {
                    "Reusing passwords",
                    "Ignoring updates",
                    "Using strong unique passwords",
                    "Sharing accounts"
                },
                CorrectAnswer = 2,
                Explanation = "Unique passwords improve security."
            });

            quizQuestions.Add(new QuizQuestion
            {
                Question = "What is the safest response to a phishing email?",
                Options = new string[]
                {
                    "Reply",
                    "Click links",
                    "Report and delete",
                    "Forward it"
                },
                CorrectAnswer = 2,
                Explanation = "Reporting phishing helps prevent scams."
            });
        }

        private void DisplayQuestion()
        {
            if (currentQuestion >= quizQuestions.Count)
            {
                ShowFinalScore();
                return;
            }

            QuizQuestion q = quizQuestions[currentQuestion];

            txtQuestion.Text = q.Question;

            btnOption1.Content = q.Options[0];
            btnOption2.Content = q.Options[1];
            btnOption3.Content = q.Options[2];
            btnOption4.Content = q.Options[3];

            txtQuizScore.Text =
                $"Score: {score}/{quizQuestions.Count}";
        }


        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            int selectedAnswer = 0;

            if (clickedButton == btnOption1)
                selectedAnswer = 0;

            else if (clickedButton == btnOption2)
                selectedAnswer = 1;

            else if (clickedButton == btnOption3)
                selectedAnswer = 2;

            else if (clickedButton == btnOption4)
                selectedAnswer = 3;

            QuizQuestion currentQuizQuestion =
                quizQuestions[currentQuestion];

            if (selectedAnswer ==
                currentQuizQuestion.CorrectAnswer)
            {
                score++;

                MessageBox.Show(
                    "Correct!\n\n" +
                    currentQuizQuestion.Explanation);
            }
            else
            {
                MessageBox.Show(
                    "Incorrect!\n\n" +
                    currentQuizQuestion.Explanation);
            }

            currentQuestion++;

            DisplayQuestion();
        }


        private void ShowFinalScore()
        {
            double percentage =
                ((double)score /
                quizQuestions.Count) * 100;

            string feedback;

            if (percentage >= 80)
            {
                feedback =
                    "Excellent! You're a cybersecurity pro!";
            }
            else if (percentage >= 60)
            {
                feedback =
                    "Good job! You have solid cybersecurity knowledge.";
            }
            else
            {
                feedback =
                    "Keep learning to stay safe online!";
            }

            AddLog(
                $"Quiz Completed - Score: {score}/{quizQuestions.Count}");

            MessageBox.Show(
                $"Quiz Complete!\n\n" +
                $"Score: {score}/{quizQuestions.Count}\n" +
                $"Percentage: {percentage:F0}%\n\n" +
                feedback);

            txtQuizScore.Text =
                $"Final Score: {score}/{quizQuestions.Count}";
        }


    }
}
