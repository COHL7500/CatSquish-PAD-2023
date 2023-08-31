namespace ConsoleApp1
{
    using System;

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
    }

    public class Var : Expr
    {
        public string Variable { get; }

        public Var(string variable)
        {
            Variable = variable;
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
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Expr e1 = new Sub(new Var("v"), new Add(new Var("w"), new Var("z")));
            Expr e2 = new Mul(new CstI(2), e1);
            Expr e3 = new Add(new Add(new Var("x"), new Var("y")), new Add(new Var("z"), new Var("v")));
            Expr e4 = new Add(new Var("x"), new CstI(0));
            Expr e5 = new Mul(new Add(new CstI(1), new CstI(0)), new Add(new Var("x"), new CstI(0)));
            Expr e6 = new Add(new Mul(new CstI(5), new Var("x")), new CstI(2));

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
                        } else if (simpExpAdd2 is CstI ca2 && ca2.ConstantInt == 0)
                        {
                            return simpExpAdd1;
                        } else
                        {
                            return new Add(simpExpAdd1, simpExpAdd2); 
                        }
                    case Sub sub:
                        var simpExpSub1 = simplify(sub.e1);
                        var simpExpSub2 = simplify(sub.e2);

                        if (simpExpSub2 is CstI cs2 && cs2.ConstantInt == 0)
                        {
                            return simpExpSub1;
                        } else if (simpExpSub1 == simpExpSub2)
                        {
                            return new CstI(0);
                        } else
                        {
                            return new Sub(simpExpSub1, simpExpSub2);
                        }
                    case Mul mul:
                        var simpExpMul1 = simplify(mul.e1);
                        var simpExpMul2 = simplify(mul.e2);
                        
                        if (simpExpMul1 is CstI cm1 && cm1.ConstantInt == 1)
                        {
                            return simpExpMul2;
                        }
                        else if (simpExpMul2 is CstI cm2 && cm2.ConstantInt == 1)
                        {
                            return simpExpMul1;
                        }
                        else if (simpExpMul1 is CstI cm3 && cm3.ConstantInt == 0)
                        {
                            return simpExpMul1;
                        }
                        else if (simpExpMul2 is CstI cm4 && cm4.ConstantInt == 0)
                        {
                            return simpExpMul2;
                        }
                        else
                        {
                            return new Mul(simpExpMul1, simpExpMul2);
                        }
                    default:
                        return e;
                }
            }

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
            
            Console.WriteLine(fmt(e1));
            Console.WriteLine(fmt(e2));
            Console.WriteLine(fmt(e3));
            Console.WriteLine(fmt(e4));
            Console.WriteLine(fmt(simplify(e5)));
            Console.WriteLine(fmt(diff(e6)));
        }
    }
}
