using QuizzMatApi.Data.BaseModels;

namespace QuizzMatApi.Data.Seed
{
    public static class AchievementSeed
    {
        public static Achievement[] GetData() =>
        [
            new()
            {
                Id = 1,
                Code = "FIRST_QUIZ",
                Title = "Первый квиз",
                Description = "Пройди свой первый квиз"
            },
            new()
            {
                Id = 2,
                Code = "PERFECT_SCORE",
                Title = "Идеально",
                Description = "Ответь верно на все вопросы квиза"
            },
            new()
            {
                Id = 3,
                Code = "TEN_QUIZZES",
                Title = "Десятка",
                Description = "Пройди 10 квизов"
            },
            new()
            {
                Id = 4,
                Code = "STREAK_7",
                Title = "Неделя подряд",
                Description = "Проходи квизы 7 дней подряд"
            }
        ];
    }
}