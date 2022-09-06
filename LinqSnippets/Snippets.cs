﻿namespace LinqSnippets
{   
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            // 1 - SELECT * of list of cars
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2 - SELECT WHERE car is audi
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }

            
        }
            
        // Examples with numbers
        static public void LinqNumber()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Obtain Each number multiplied by 3
            // take all numbers, but 9
            // Ascending order

            var processedNumberList =
                numbers
                .Select(num => num * 3) // 3, 6
                .Where(num => num != 0) // all but the 9
                .OrderBy(num => num);   // at the end order the numbers

        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };
            // 1 - Seach the first of the elements
            var first = textList.First();

            // 2 - First element that has  "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3 - First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4 - First element containing z or default
            var fisrtOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            // 5 - 4 - Last element containing z or default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            // 6 - Returning a single value
            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8};
            int[] otherEvenNumbers = { 0, 2, 6 };

            // Obtaining { 4, 8 }
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);
        }

        public static void MultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionsSelection = myOpinions.Select(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id =1,
                            Name = "Rui",
                            Email = "rrqulquier@gmail.com",
                            Salary = 3000
                        },
                          new Employee
                        {
                            Id =2,
                            Name = "João",
                            Email = "joao@gmail.com",
                            Salary = 1580
                        },
                            new Employee
                        {
                            Id =3,
                            Name = "Manuel",
                            Email = "manumanu@gmail.com",
                            Salary = 2500
                        }
                    }
                },
                 new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id =4,
                            Name = "Elizabethy",
                            Email = "bethy@gmail.com",
                            Salary = 3000
                        },
                          new Employee
                        {
                            Id =5,
                            Name = "Pablo",
                            Email = "jpablo@gmail.com",
                            Salary = 2700
                        },
                            new Employee
                        {
                            Id =6,
                            Name = "Ligia",
                            Email = "li@gmail.com",
                            Salary = 2000
                        }
                    }
                }
            };

            // Obtaining all employees of all enterprises
            var employeeList = enterprises.SelectMany(selector: enterprise => enterprise.Employees);

            // Know if any list is empmpty 
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // All enterprises at least have one employee with >= 1000 salary
            bool hasEmployeeWithSalaryMoreThanEqual1000 =
                enterprises.Any(enterprise =>
                    enterprise.Employees.Any(employee => 
                    employee.Salary >= 1000));

        }

        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonElement2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement }
                );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s =>
                                 s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };


            // OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };

            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            var skipTwoFirstValues = myList.Skip(2);

            var skipLastTwoValues = myList.Skip(2);

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4);

            // TAKE
            var takeFirstTwoValues = myList.Take(2);


            var takeLastTwoValues = myList.TakeLast(2);

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);
        }

        // Variables


        // ZIP


        // Repeat


        // ALL


        // Aggregate


        // Distinct


        // GroupBy


    }
}