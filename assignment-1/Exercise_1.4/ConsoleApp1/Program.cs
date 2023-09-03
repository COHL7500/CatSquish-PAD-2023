namespace ConsoleApp1
{
    using System;
    
    // -------------------------------------------------------
    // EXERCISE 1.4
    // -------------------------------------------------------

    public class lookup
    {
        private Dictionary<string, int> env = new()
        {
            { "a", 3 },
            { "c", 78 },
            { "baf", 666 },
            { "b", 111 }
        };

        public void add(string a, int b)
        {
            env.Add(a, b);
        }

        public int find(string a)
        {
            if (env.TryGetValue(a, out int value))
            {
                return value;
            }

            throw new Exception($"{a} not found");
        }
    }

    public abstract class Expr
    {
    }

    public class CstI : Expr
    {
        public int ConstantInt { get; }

        public CstI(int constant)
        {
            ConstantInt = constant;
        }

        public override string ToString()
        {
            return ConstantInt.ToString();
        }
    }

    public class Var : Expr
    {
        public string Variable { get; }

        public Var(string variable)
        {
            Variable = variable;
        }

        public override string ToString()
        {
            return Variable;
        }
    }

    public class Add : Expr
    {
        public Expr e1 { get; }
        public Expr e2 { get; }

        public Add(Expr expr1, Expr expr2)
        {
            e1 = expr1;
            e2 = expr2;
        }

        public override string ToString()
        {
            return $"({e1} + {e2})";
        }
    }

    public class Mul : Expr
    {
        public Expr e1 { get; }
        public Expr e2 { get; }

        public Mul(Expr expr1, Expr expr2)
        {
            e1 = expr1;
            e2 = expr2;
        }

        public override string ToString()
        {
            return $"({e1} * {e2})";
        }
    }

    public class Sub : Expr
    {
        public Expr e1 { get; }
        public Expr e2 { get; }

        public Sub(Expr expr1, Expr expr2)
        {
            e1 = expr1;
            e2 = expr2;
        }

        public override string ToString()
        {
            return $"({e1} - {e2})";
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            lookup l = new lookup();
            Expr e1 = new Sub(new Var("v"), new Add(new Var("w"), new Var("z")));
            Expr e2 = new Mul(new CstI(2), e1);
            Expr e3 = new Add(new Add(new Var("x"), new Var("y")), new Add(new Var("z"), new Var("v")));
            Expr e4 = new Add(new Var("x"), new CstI(0));
            Expr e5 = new Mul(new Add(new CstI(1), new CstI(0)), new Add(new Var("x"), new CstI(0)));
            Expr e6 = new Add(new Mul(new CstI(5), new Var("x")), new CstI(2));
            Expr e7 = new CstI(17);
            Expr e8 = new Add(new CstI(3), new Var("a"));
            Expr e9 = new Add(new Var("a"), new Mul(new Var("b"), new CstI(9)));

            // EVAL ENVIRONMENT //
            
            int eval(Expr e)
            {
                switch (e)
                {
                    case CstI i:
                        return i.ConstantInt;
                    case Var x:
                        return l.find(x.Variable);
                    case Add add:
                        return eval(add.e1) + eval(add.e2);
                    case Mul mul:
                        return eval(mul.e1) * eval(mul.e2);
                    case Sub sub:
                        return eval(sub.e1) - eval(sub.e2);
                    default:
                        throw new ArgumentException("Unknown expression type");
                }
            }
            
            // FMT ENVIRONMENT //

            string fmt(Expr e)
            {
                switch (e)
                {
                    case CstI c:
                        return c.ConstantInt.ToString();
                    case Var v:
                        return v.Variable;
                    case Add add:
                        return $"({fmt(add.e1)} + {fmt(add.e2)})";
                    case Mul mul:
                        return $"({fmt(mul.e1)} * {fmt(mul.e2)})";
                    case Sub sub:
                        return $"({fmt(sub.e1)} - {fmt(sub.e2)})";
                    default:
                        throw new ArgumentException("Unknown expression type");
                }
            }
            
            // SIMPLIFY ENVIRONMENT //
            
            Expr simplify(Expr e)
            {
                switch (e)
                {
                    case Add add:
                        var simpExpAdd1 = simplify(add.e1);
                        var simpExpAdd2 = simplify(add.e2);

                        if (simpExpAdd1 is CstI ca1 && ca1.ConstantInt == 0)
                        {
                            return simpExpAdd2;
                        }

                        if (simpExpAdd2 is CstI ca2 && ca2.ConstantInt == 0)
                        {
                            return simpExpAdd1;
                        }

                        return new Add(simpExpAdd1, simpExpAdd2);
                    
                    case Sub sub:
                        var simpExpSub1 = simplify(sub.e1);
                        var simpExpSub2 = simplify(sub.e2);

                        if (simpExpSub2 is CstI cs2 && cs2.ConstantInt == 0)
                        {
                            return simpExpSub1;
                        }
                        if (simpExpSub1 == simpExpSub2)
                        {
                            return new CstI(0);
                        }

                        return new Sub(simpExpSub1, simpExpSub2);
                    
                    case Mul mul:
                        var simpExpMul1 = simplify(mul.e1);
                        var simpExpMul2 = simplify(mul.e2);

                        if (simpExpMul1 is CstI cm1 && cm1.ConstantInt == 1)
                        {
                            return simpExpMul2;
                        }
                        
                        if (simpExpMul2 is CstI cm2 && cm2.ConstantInt == 1)
                        {
                            return simpExpMul1;
                        }
                        
                        if (simpExpMul1 is CstI cm3 && cm3.ConstantInt == 0)
                        {
                            return simpExpMul1;
                        }
                        
                        if (simpExpMul2 is CstI cm4 && cm4.ConstantInt == 0)
                        {
                            return simpExpMul2;
                        }
                        
                        return new Mul(simpExpMul1, simpExpMul2);
                    
                    default:
                        return e;
                }
            }
            
            // SYMBOLIC DIFFERENTIATION ENVIRONMENT //
            
            Expr diff(Expr e)
            {
                switch (e)
                {
                    case CstI:
                        return new CstI(0);
                    case Var:
                        return new CstI(1);
                    case Add add:
                        var diffExpAdd1 = diff(add.e1);
                        var diffExpAdd2 = diff(add.e2);
                        return simplify(new Add(diffExpAdd1, diffExpAdd2));
                    case Mul mul:
                        var diffExpMul1 = diff(mul.e1);
                        var diffExpMul2 = diff(mul.e2);
                        return simplify(new Mul(mul.e1, diffExpMul2));
                    case Sub sub:
                        var diffExpSub1 = diff(sub.e1);
                        var diffExpSub2 = diff(sub.e2);
                        return simplify(new Sub(diffExpSub1, diffExpSub2));
                    default:
                        throw new ArgumentException("Unknown expression type");
                }
            }
            
            // EVALUATION OF EXPRESSIONS //
            
            // to string
            Console.Out.WriteLine(e1.ToString());
            Console.Out.WriteLine(e2.ToString());
            Console.Out.WriteLine(e3.ToString());
            Console.Out.WriteLine(e4.ToString());
            Console.Out.WriteLine(e5.ToString());
            Console.Out.WriteLine(e6.ToString());
            
            // eval
            Console.Out.WriteLine(eval(e7));
            Console.Out.WriteLine(eval(e8));
            Console.Out.WriteLine(eval(e9));

            // fmt
            Console.WriteLine(fmt(e1));
            Console.WriteLine(fmt(e2));
            Console.WriteLine(fmt(e3));
            Console.WriteLine(fmt(e4));
            Console.WriteLine(fmt(simplify(e5)));
            Console.WriteLine(fmt(diff(e6)));
        }
    }
}