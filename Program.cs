using System;
using System.Media;
using System.Threading;

public class CybersecurityChatbot
{


    private static readonly string AsciiArt = @"

     _____                          _                     _                
  / ____|                        | |                   | |               
 | |     _ __ __ _ _ __ ___  ___| |_ _ __ __ _ _ __ | |_ ___ _ __ ___  
 | |    | '__/ _` | '__/ _ \/ __| __| '__/ _` | '_ \| __/ _ \ '_ ` _ \ 
 | |____| | | (_| | | |  __/ (__| |_| | | (_| | | | | ||  __/ | | | | |
  \_____|_|  \__,_|_|  \___|\___|\__|_|  \__,_|_| |_|\__\___|_| |_| |_|
                                                                        
             ___                                 _     _                     
            / _ \                               | |   | |                    
           / /_\ \_ __ __ _ _ __ ___   ___ _ __| |__ | |_ ___  _ __ ___ ___  
           |  _  | '__/ _` | '_ ` _ \ / _ \ '__| '_ \| __/ _ \| '__/ __/ _ \ 
           | | | | | | (_| | | | | | |  __/ |  | | | | || (_) | | | (_|  __/ 
           \_| |_/_|  \__,_|_| |_| |_|\___|_|  |_| |_|\__\___|_|  \___\___| 
                                                                             
       .--------------------.    .--------------------.    .--------------------.  
       |  1. Don’t click on   |    |  2. Use strong      |    |  3. Browse safely  |  
       |     unknown links    |    |     passwords        |    | (HTTPS, VPN)      |  
       |  4. Verify senders    |    |  5. Change passwords |    |  Avoid public Wi-Fi|  
       |  6. Keep software     |    | regularly            |    |  Be cautious       |  
       |     updated           |    |  7. Enable 2FA      |    |                    |  
       '--------------------'    '--------------------'    '--------------------'  
";
        
    


    public static void Main(string[] args)
    {
        DisplayAsciiArt();
        PlayGreeting();
        GreetUser();
        DisplayHeader("Cybersecurity Q&A");
        HandleUserQuery();
        DisplayDivider();
        Console.WriteLine("Thank you for using the Cybersecurity Awareness Bot!");
    }

    private static void PlayGreeting()
    {
        try
        {
            //Get the directory where the executable is running
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //Build a relative path to the sound file
            string soundPath = Path.Combine(appDirectory, "sound.wav");

            if (File.Exists(soundPath))
            {
                SoundPlayer player = new SoundPlayer(soundPath);
                player.PlaySync();
            }
            else
            {
                Console.WriteLine("Error: Sound file not found!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing greeting: {ex.Message}");
        }
    }

    private static void DisplayAsciiArt()
    {
        Console.WriteLine(AsciiArt);
    }

    private static void GreetUser()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"\nWelcome, {name}! I'm the Cybersecurity Awareness Bot.");
    }

    private static void HandleUserQuery()
    {
        while (true)
        {
            Console.Write("\nAsk me a question (or type 'exit'): ");
            string query = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Please enter a valid question.");
                continue;
            }

            if (query.ToLower() == "exit")
                break;

            TypeWriteLine(GetResponse(query.ToLower()));
        }
    }

    private static string GetResponse(string query)
    {
        if (query.Contains("how are you"))
            return "I'm doing well, thank you!";
        else if (query.Contains("purpose"))
            return "My purpose is to help you learn about cybersecurity.";
        else if (query.Contains("ask you about"))
            return "You can ask me about password safety, phishing, safe browsing, and more.";
        else if (query.Contains("password safety"))
            return "Use strong, unique passwords and consider a password manager.";
        else if (query.Contains("phishing"))
            return "Be cautious of suspicious emails and links. Never share sensitive information.";
        else if (query.Contains("safe browsing"))
            return "Use reputable websites, keep your software updated, and avoid clicking on unknown links.";
        else
            return "I didn’t quite understand that. Could you rephrase?";
    }

    private static void DisplayHeader(string headerText)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("========================================");
        Console.WriteLine($" {headerText}");
        Console.WriteLine("========================================");
        Console.ResetColor();
    }

    private static void DisplayDivider()
    {
        Console.WriteLine("----------------------------------------");
    }

    private static void TypeWriteLine(string text, int delay = 50)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }
}