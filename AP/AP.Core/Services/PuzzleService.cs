using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP.Core.Interfaces;
using AP.Data.Repositories;
using AP.Models.Entities;

namespace AP.Core.Services
{
    public class PuzzleService : IPuzzleService
    {
        private readonly IPuzzleRepository repository;

        public PuzzleService()
        {
            repository = new PuzzleRepository();
        }

        public List<Puzzle> GetAll()
        {
            return repository.GetAll();
        }

        public Puzzle GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Add(Puzzle puzzle)
        {
            repository.Add(puzzle);
        }

        public void Update(Puzzle puzzle)
        {
            repository.Update(puzzle);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public GameQuestion GenerateQuestion()
        {
            Random random = new Random();

            int number1 = random.Next(2, 20);
            int number2 = random.Next(2, 20);

            int operation = random.Next(0, 3);

            string question;
            int answer;

            switch (operation)
            {
                case 0:
                    question = $"¿Cuánto es {number1} + {number2}?";
                    answer = number1 + number2;
                    break;

                case 1:
                    question = $"¿Cuánto es {number1} - {number2}?";
                    answer = number1 - number2;
                    break;

                default:
                    question = $"¿Cuánto es {number1} × {number2}?";
                    answer = number1 * number2;
                    break;
            }

            List<string> options = new List<string>
{
    answer.ToString(),
    (answer + random.Next(1, 5)).ToString(),
    (answer - random.Next(1, 5)).ToString(),
    (answer + random.Next(6, 10)).ToString()
};

            // Mezclar las respuestas
            options = options.OrderBy(x => random.Next()).ToList();

            return new GameQuestion
            {
                Question = question,

                OptionA = options[0],

                OptionB = options[1],

                OptionC = options[2],

                OptionD = options[3],

                CorrectAnswer = answer.ToString(),

                Points = 10,

                Difficulty = 1
            };
        }
    }
}