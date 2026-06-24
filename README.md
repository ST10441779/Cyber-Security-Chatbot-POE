# 🛡️ Cybersecurity Awareness Chatbot (WPF C#)

## 📌 Project Overview

The Cybersecurity Awareness Chatbot is a WPF desktop application developed using C# in Visual Studio 2022. It is designed to educate users about cybersecurity concepts through interactive features such as a chatbot, task manager, quiz game, and activity logging system.

---

## 🚀 Features

### 💬 1. Chatbot with NLP Simulation
- Uses keyword detection to simulate natural language processing
- Recognises cybersecurity-related terms such as:
  - Password
  - Phishing
  - VPN
  - Malware
  - 2FA
- Provides instant educational responses
- Includes command: “what have you done for me”

---

### 📋 2. Task Assistant
- Add cybersecurity-related tasks
- Optional reminder date selection
- Mark tasks as completed
- Delete tasks
- Displays all tasks in a list

Example tasks:
- Enable Two-Factor Authentication
- Review privacy settings
- Update passwords

---

### 🎮 3. Cybersecurity Quiz Game
- 10+ multiple-choice questions
- Covers topics:
  - Phishing
  - Password security
  - VPN
  - Malware
  - Social engineering
- Instant feedback after each answer
- Final score with performance feedback

---

### 📝 4. Activity Log System
- Tracks all user actions
- Logs:
  - Chatbot interactions
  - Task creation and updates
  - Quiz attempts
- Displays last 5–10 activities

---

## 🧠 Technologies Used

- C#
- WPF (Windows Presentation Foundation)
- .NET 8
- XAML (UI Design)
- Event-driven programming

---

## 📂 Project Structure
CyberSecurityAwarenessChatbot
│
├── Data
│   └── ChatbotResponses.cs
│
├── Models
│   ├── TaskItem.cs
│   ├── QuizQuestion.cs
│   └── ActivityLog.cs
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
└── App.xaml

## ▶️ How to Run the Project

1. Open Visual Studio 2022
2. Load the project folder
3. Restore NuGet packages (if needed)
4. Build the solution
5. Run using `Start (F5)`

---

## 📊 Learning Outcomes

This project demonstrates:
- GUI development using WPF
- Event-driven programming
- Basic NLP simulation using string matching
- Data handling using lists
- User interaction tracking
- Modular application design

---

## 👨‍💻 Author
Rethabile Minnaar
