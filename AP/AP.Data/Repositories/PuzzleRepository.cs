using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP.Models.Entities;

namespace AP.Data.Repositories
{
    public class PuzzleRepository : IPuzzleRepository
    {
        private static List<Puzzle> puzzles = new List<Puzzle>()
        {
            new Puzzle
            {
                Id = 1,
                Question = "¿Cuánto es 5 + 5?",
                Answer = 10,
                Difficulty = 1,
                Points = 10
            },
            new Puzzle
            {
                Id = 2,
                Question = "¿Cuánto es 8 × 7?",
                Answer = 56,
                Difficulty = 2,
                Points = 20
            }
        };

        public List<Puzzle> GetAll()
        {
            return puzzles;
        }

        public Puzzle GetById(int id)
        {
            return puzzles.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Puzzle puzzle)
        {
            puzzle.Id = puzzles.Count + 1;
            puzzles.Add(puzzle);
        }

        public void Update(Puzzle puzzle)
        {
            var current = GetById(puzzle.Id);

            if (current != null)
            {
                current.Question = puzzle.Question;
                current.Answer = puzzle.Answer;
                current.Difficulty = puzzle.Difficulty;
                current.Points = puzzle.Points;
            }
        }

        public void Delete(int id)
        {
            var puzzle = GetById(id);

            if (puzzle != null)
                puzzles.Remove(puzzle);
        }
    }
}