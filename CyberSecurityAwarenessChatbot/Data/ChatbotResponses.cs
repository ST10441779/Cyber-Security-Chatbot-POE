namespace CyberSecurityAwarenessChatbot.Data
{
    public static class ChatbotResponses
    {
        public static Dictionary<string, string> Responses =
            new Dictionary<string, string>()
        {
            {
                "password",
                "Use strong passwords that contain letters, numbers and symbols."
            },

            {
                "phishing",
                "Phishing attacks attempt to steal your personal information."
            },

            {
                "vpn",
                "A VPN encrypts your internet connection and improves privacy."
            },

            {
                "malware",
                "Malware is harmful software designed to damage systems."
            },

            {
                "privacy",
                "Review your privacy settings regularly to protect your data."
            },

            {
                "2fa",
                "Two-factor authentication adds an extra layer of protection."
            }
        };
    }
}
