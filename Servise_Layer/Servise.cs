#nullable enable
using System;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Collections.Generic;
using Business_Layer.Objects;
using Data_Layer.Objects;

namespace Servise_Layer.Object
{
    public static class Servise
    {
        private static CategoryDAO? categoryDAO;
        private static ProductDAO? productDAO;
        private static DailyRation ration = new();
        private static User user = new();

        public static void SetPath(string path)
        {
            categoryDAO = new(path);
            productDAO = new(path);
            ration = new();
        }

        public static HashSet<Category> GetCategories()
        {
            if(categoryDAO == null)
            {
                throw new ArgumentNullException(nameof(categoryDAO));
            }

            return categoryDAO.GetCategories();
        }

        public static Category? GetCategory(string name)
        {
            foreach (Category category in GetCategories())
            {
                if (category.Name == name)
                {
                    return category;
                }
            }

            return null;
        }

        public static HashSet<Product> GetProductsOf(string name)
        {
            if (categoryDAO == null)
            {
                throw new ArgumentNullException(nameof(categoryDAO));
            }

            Category? products = GetCategory(name);
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return products.GetProducts;
        }

        public static List<MealTime> GetRation ()
        {
            return ration.GetRation;
        }

        public static void AddMeal(MealTime meal)
        {
            ration.Add(meal);
        }

        public static void DelMeal(MealTime meal)
        {
            ration.Remove(meal);
        }

        public static void SetUserHeight(double height)
        {
            user.Height = height;
        }

        public static void SetUserWeight(double weight)
        {
            user.Weight = weight;
        }

        public static void SetUserAge(int age)
        {
            user.Age = age;
        }

        public static void SetUserActivity(double coef)
        {
            user.ActivityCoef = coef;
        }

        public static int GetDailyRate()
        {
            return (int)user.GetDailyRate();
        }

        public static bool UserValidate(ref string message)
        {
           return user.Validate(ref message);
        }

        public static float GetCalories()
        {
            return ration.GetCalories();
        }

        public static void SaveToPdf()
        {
            using PdfDocument document = new();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            string column1 = string.Format("Weight: {0} kg\nHeight: {1} cm\nAge: {2}\nActivity: {3}", user.Weight, user.Height, user.Age, user.GetActivity());
            string column2 = string.Format("Protein: {0}\nCarbs: {1}\nFats: {2}\nCalories: {3}", ration.GetProtein(), ration.GetCarbs(), ration.GetFats(), ration.GetCalories()); 

            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 35, PdfFontStyle.Bold);
            PdfFont font1 = new PdfStandardFont(PdfFontFamily.Courier, 17);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.Courier, 17, PdfFontStyle.Bold);
            PdfFont font4 = new PdfTrueTypeFont(new Font("Perpetua Titling MT", 14, FontStyle.Bold), true);
            PdfFont font5 = new PdfTrueTypeFont(new Font("Arial", 10), true);

            PdfImage image = PdfImage.FromFile(@"D:\The_3_semestr\Daily Meal Planner\Pictures\image.png");
            PdfImage image1 = PdfImage.FromFile(@"D:\The_3_semestr\Daily Meal Planner\Pictures\MealTimeee.png");
            graphics.DrawImage(image, 250, 200);

            graphics.DrawLine(new PdfPen(Color.SaddleBrown, 5), new PointF(10, 20), new PointF(500, 20));
            graphics.DrawLine(new PdfPen(Color.SaddleBrown, 1), new PointF(10, 105), new PointF(500, 105));
            graphics.DrawString("Daily food ration", font, PdfBrushes.SaddleBrown, new PointF(125, 40));
            graphics.DrawString("User parameters", font2, PdfBrushes.SaddleBrown, new PointF(15, 125));
            graphics.DrawString(column1, font1, PdfBrushes.Black, new PointF(20, 155));
            graphics.DrawString("Daily rate", font2, PdfBrushes.SaddleBrown, new PointF(335, 125));
            graphics.DrawString(column2, font1, PdfBrushes.Black, new PointF(340, 155));
            graphics.DrawLine(new PdfPen(Color.SaddleBrown, 1), new PointF(10, 250), new PointF(329, 250));
            graphics.DrawLine(new PdfPen(Color.SaddleBrown, 1), new PointF(344, 250), new PointF(376, 250));

            int posY = 250;
            foreach (MealTime meal in ration.GetRation)
            {
                graphics.DrawImage(image1, 10, posY);
                graphics.DrawString($"{meal.Name}", font4, PdfBrushes.SaddleBrown, new PointF(100, posY + 15));
                foreach (Product product in meal.GetMealTime)
                {
                    posY += 35;
                    graphics.DrawString($"{product.Name}........{product.Calories} kcal", font5, PdfBrushes.Black, new PointF(100, posY));
                    posY -= 20;
                }
                posY += 70;
            }

            graphics.DrawLine(new PdfPen(Color.SaddleBrown, 1), new PointF(10, posY), new PointF(500, posY));
            graphics.DrawString($"Total Calories: {ration.GetCalories()} kcal.", font4, PdfBrushes.SaddleBrown, new PointF(10, posY + 15));


            document.Save("Output.pdf");
            document.Close(true);
        }
    }
}
