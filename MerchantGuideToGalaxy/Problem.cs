using MerchantGuideToGalaxy.Contexts;
using MerchantGuideToGalaxy.Parsers;
using MerchantGuideToGalaxy.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MerchantGuideToGalaxy
{
    internal class Problem
    {
        public static void Process(List<string> input)
        {
            Parsers.Parser[] parsers;
            Solver[] solvers;
            Context ctx = Initialize(out parsers, out solvers);

            ParseValues(input, parsers);
            ProcessQuestion(ctx, solvers);
            Console.ReadKey();
        }

        private static Context Initialize(out Parsers.Parser[] parsers, out Solver[] solvers)
        {
            var ctx = new Context();

            parsers = new Parsers.Parser[]
            {
                new PrimitiveParser(ctx),
                new UnitParser(ctx),
                new QuestionParser(ctx)
            };

            solvers = new Solver[]
            {
                new PrimitiveSolver(ctx),
                new UnitSolver(ctx)

            };
            return ctx;
        }

        private static void ParseValues(List<string> input, IEnumerable<Parsers.Parser> parsers)
        {
            input
                .ForEach(cmd => parsers.ToList()
                    .ForEach(parser =>
                    {
                        try
                        {
                            parser.Parse(cmd);
                        }
                        catch
                        {
                        }
                    }));
        }

        private static void ProcessQuestion(Context ctx, IEnumerable<Solver> solvers)
        {
            ctx.Questions.ForEach(cmd =>
            {
                var solved = false;
                solvers.ToList().ForEach(solver =>
                {
                    string answer = string.Empty;
                    try
                    {
                        if (solver.Solve(cmd, out answer))
                        {
                            solved = true;
                        }
                    }
                    catch
                    {
                    }
                });
                if (!solved)
                {
                    Console.WriteLine("I have no idea what you are talking about");
                }
            });
        }
    }
}
