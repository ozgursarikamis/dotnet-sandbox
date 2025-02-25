using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary.AdvancedTopics;

public static class ActionBlockExample
{
    public static async Task Run()
    {
        // ActionBlock to send email notifications:
        var emailSender = new ActionBlock<EmailNotification>(async notification =>
        {
            // Simulate sending email:
            await Task.Delay(1000);

            Console.WriteLine($"Email sent to: {notification.Recipient}");
            Console.WriteLine($"Subject: {notification.Subject}");
            Console.WriteLine($"Body: {notification.Body}");
            Console.WriteLine("===");
        });

        // Simulate receiving email notifications:
        EmailNotification[] notifications =
        [
            new() { Recipient = "alice@example.com", Subject = "Welcome!", Body = "Welcome to our service." },
            new() { Recipient = "bob@example.com", Subject = "Update", Body = "Your account has been updated." },
            new() { Recipient = "charlie@example.com", Subject = "Reminder", Body = "Don't forget your appointment." }
        ];

        foreach (var notification in notifications)
            emailSender.Post(notification);
        
        // Signal completion:
        emailSender.Complete();
        await emailSender.Completion;

        Console.WriteLine("Email sending complete.");
        Console.ReadKey();
    }
}

class EmailNotification
{
    public string Recipient { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}