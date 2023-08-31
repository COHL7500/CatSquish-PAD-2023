namespace ConsoleApp1
{
    using System;
    
    // Object language expressions with variables
    
    public abstract class AExpr
    {
    }
    
    public class CstI : AExpr
    {
        public int Value { get; }
        
        public CstI(int value)
        {
            Value = value;
        }
    }
    
    public class Var : AExpr
    {
        public string Name { get; }
        
        public Var(string name)
        {
            Name = name;
        }
    }
    
    public class Add : AExpr
    {
        public AExpr Expr1 { get; }
        public AExpr Expr2 { get; }
        
        public Add(AExpr expr1, AExpr expr2)
        {
            Expr1 = expr1;
            Expr2 = expr2;
        }
    }
    
    public class Mul : AExpr
    {
        public AExpr Expr1 { get; }
        public AExpr Expr2 { get; }
        
        public Mul(AExpr expr1, AExpr expr2)
        {
            Expr1 = expr1;
            Expr2 = expr2;
        }
    }
    
    public class Sub : AExpr
    {
        public AExpr Expr1 { get; }
        public AExpr Expr2 { get; }
        
        public Sub(AExpr expr1, AExpr expr2)
        {
            Expr1 = expr1;
            Expr2 = expr2;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            AExpr e1 = new Sub(new Var("v"), new Add(new Var("w"), new Var("z")));
            AExpr e2 = new Mul(new CstI(2), e1);
            AExpr e3 = new Add(new Add(new Var("x"), new Var("y")), new Add(new Var("z"), new Var("v")));
            AExpr e4 = new Add(new Var("x"), new CstI(0));
            AExpr e5 = new Mul(new Add(new CstI(1), new CstI(0)), new Add(new Var("x"), new CstI(0)));
            AExpr e6 = new Add(new Mul(new CstI(5), new Var("x")), new CstI(2));

            string fmt(AExpr a)
            {
                if (a is CstI cstI)
                {
                    return cstI.Value.ToString();
                }
                else if (a is Var var)
                {
                    return var.Name;
                }
                else if (a is Add add)
                {
                    return $"({fmt(add.Expr1)} + {fmt(add.Expr2)})";
                }
                else if (a is Mul mul)
                {
                    return $"({fmt(mul.Expr1)} * {fmt(mul.Expr2)})";
                }
                else if (a is Sub sub)
                {
                    return $"({fmt(sub.Expr1)} - {fmt(sub.Expr2)})";
                }
                else
                {
                    throw new ArgumentException("Unknown expression type");
                }
            }

            AExpr simplify(AExpr a)
            {
                if (a is Add add)
                {
                    var simplifiedExpr1 = simplify(add.Expr1);
                    var simplifiedExpr2 = simplify(add.Expr2);

                    if (simplifiedExpr1 is CstI cst1 && cst1.Value == 0)
                    {
                        return simplifiedExpr2;
                    }
                    else if (simplifiedExpr2 is CstI cst2 && cst2.Value == 0)
                    {
                        return simplifiedExpr1;
                    }
                    else
                    {
                        return new Add(simplifiedExpr1, simplifiedExpr2);
                    }
                }
                else if (a is Sub sub)
                {
                    var simplifiedExpr1 = simplify(sub.Expr1);
                    var simplifiedExpr2 = simplify(sub.Expr2);

                    if (simplifiedExpr2 is CstI cst2 && cst2.Value == 0)
                    {
                        return simplifiedExpr1;
                    }
                    else if (simplifiedExpr1 == simplifiedExpr2)
                    {
                        return new CstI(0);
                    }
                    else
                    {
                        return new Sub(simplifiedExpr1, simplifiedExpr2);
                    }
                }
                else if (a is Mul mul)
                {
                    var simplifiedExpr1 = simplify(mul.Expr1);
                    var simplifiedExpr2 = simplify(mul.Expr2);

                    if (simplifiedExpr1 is CstI cst1 && cst1.Value == 1)
                    {
                        return simplifiedExpr2;
                    }
                    else if (simplifiedExpr2 is CstI cst2 && cst2.Value == 1)
                    {
                        return simplifiedExpr1;
                    }
                    else if (simplifiedExpr1 is CstI cst3 && cst3.Value == 0)
                    {
                        return simplifiedExpr1;
                    }
                    else if (simplifiedExpr2 is CstI cst4 && cst4.Value == 0)
                    {
                        return simplifiedExpr2;
                    }
                    else
                    {
                        return new Mul(simplifiedExpr1, simplifiedExpr2);
                    }
                }
                else
                {
                    return a;
                }
            }

            AExpr diff(AExpr a)
            {
                if (a is CstI)
                {
                    return new CstI(0);
                }
                else if (a is Var)
                {
                    return new CstI(1);
                }
                else if (a is Add add)
                {
                    var diffExpr1 = diff(add.Expr1);
                    var diffExpr2 = diff(add.Expr2);
                    return simplify(new Add(diffExpr1, diffExpr2));
                }
                else if (a is Mul mul)
                {
                    var diffExpr1 = diff(mul.Expr1);
                    var diffExpr2 = diff(mul.Expr2);
                    return simplify(new Mul(mul.Expr1, diffExpr2));
                }
                else if (a is Sub sub)
                {
                    var diffExpr1 = diff(sub.Expr1);
                    var diffExpr2 = diff(sub.Expr2);
                    return simplify(new Sub(diffExpr1, diffExpr2));
                }
                else
                {
                    throw new ArgumentException("Unknown expression type");
                }
            }

            Console.WriteLine(fmt(simplify(e5)));
            Console.WriteLine(fmt(diff(e6)));
        }
    }
}