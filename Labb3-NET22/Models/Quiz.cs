using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Labb3_NET22.Models;

public class Quiz
{
    /*private static string _quizPath;
    private static string quizFileName = "LabQuestions.json";
    private static string quizFolder = @"Lab 3";

    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };*/

    /*public Quiz()
    {
        string localAppdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        _quizPath = Path.Combine(localAppdataPath, quizFolder);

        string tempPath = Path.Combine(_quizPath, quizFileName);

        if (!File.Exists(tempPath))
        {
            SaveUserQuestions(LoadDefaultQuestions());
        }
    }*/

    /*public static List<Question> LoadUserQuestions()
    {
        string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), quizFolder, quizFileName);

        if (File.Exists(tempPath))
        {
            string jsonString = File.ReadAllText(tempPath);
            List<Question> questions = JsonSerializer.Deserialize<List<Question>>(jsonString, options);
            return questions;
        }
        else
        {
            Console.WriteLine("The file you're looking for does not exist.");
            return null;
        }
    }*/

    /*public static void SaveUserQuestions(List<Question> questions)
    {
        if (!Directory.Exists(_quizPath))
        {
            Directory.CreateDirectory(_quizPath);
        }

        string json = JsonSerializer.Serialize(questions);
        File.WriteAllText(Path.Combine(_quizPath, quizFileName), json);

        Console.WriteLine($"Saved {questions.Count} questions.");
    }*/
    
    /*public static List<Question> LoadDefaultQuestions()
    {
        string defaultQuestionsPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "DataModels", "LabQuestions.json");

        string jsonReading = File.ReadAllText(defaultQuestionsPath);
        List<Question> questions = JsonSerializer.Deserialize<List<Question>>(jsonReading, options);
        return questions;
    }*/
}