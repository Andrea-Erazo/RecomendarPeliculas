using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRecommendationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Base de datos de películas
            var movies = new List<Movie>
            {
                new Movie("The Avengers", "Action", "Medium", "Adventure"),
                new Movie("The Shawshank Redemption", "Drama", "Long", "Romantic"),
                new Movie("Die Hard", "Action", "Short", "Thriller"),
                new Movie("Titanic", "Drama", "Long", "Romantic"),
                new Movie("Toy Story", "Animation", "Short", "Adventure")
            };

            // Obtener preferencias del usuario
            Console.WriteLine("¿Qué género prefieres? (e.g., Acción, Drama, Comedia)");
            string genre = Console.ReadLine();

            Console.WriteLine("¿Cuál es tu duración ideal de película? (e.g., Corta, Media, Larga)");
            string duration = Console.ReadLine();

            Console.WriteLine("¿Tienes algún estilo específico en mente? (e.g., Aventura, Romántica)");
            string style = Console.ReadLine();

            // Buscar recomendaciones
            var recommendations = movies.Where(m =>
                m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase) &&
                m.Duration.Equals(duration, StringComparison.OrdinalIgnoreCase) &&
                m.Style.Equals(style, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            // Mostrar resultados
            if (recommendations.Any())
            {
                Console.WriteLine("Recomendaciones para ti:");
                foreach (var movie in recommendations)
                {
                    Console.WriteLine($"- {movie.Title} (Recomendado)");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron películas que coincidan con tus preferencias.");
            }
        }
    }

    class Movie
    {
        public string Title { get; }
        public string Genre { get; }
        public string Duration { get; }
        public string Style { get; }

        public Movie(string title, string genre, string duration, string style)
        {
            Title = title;
            Genre = genre;
            Duration = duration;
            Style = style;
        }
    }
}
