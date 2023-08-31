

// Object language expressions with variables

public abstract class AExpr
{
}

public partial class CstII : AExpr
{
    public int Value { get; }
    
    public CstII(int value)
    {
        Value = value;
    }
}

public partial class Varr : AExpr
{
    public string Name { get; }
    
    public Varr(string name)
    {
        Name = name;
    }
}

public class Addd : AExpr
{
    public AExpr Expr1 { get; }
    public AExpr Expr2 { get; }
    
    public Addd(AExpr expr1, AExpr expr2)
    {
        Expr1 = expr1;
        Expr2 = expr2;
    }
}

public class Mull : AExpr
{
    public AExpr Expr1 { get; }
    public AExpr Expr2 { get; }
    
    public Mull(AExpr expr1, AExpr expr2)
    {
        Expr1 = expr1;
        Expr2 = expr2;
    }
}

public class Subb : AExpr
{
    public AExpr Expr1 { get; }
    public AExpr Expr2 { get; }
    
    public Subb(AExpr expr1, AExpr expr2)
    {
        Expr1 = expr1;
        Expr2 = expr2;
    }
}

/*
class Programm
{
    private static void Main(string[] args)
    {
        AExpr e1 = new Subb(new Varr("v"), new Addd(new Varr("w"), new Varr("z")));
        AExpr e2 = new Mull(new CstII(2), e1);
        AExpr e3 = new Addd(new Addd(new Varr("x"), new Varr("y")), new Addd(new Varr("z"), new Varr("v")));
        AExpr e4 = new Addd(new Varr("x"), new CstII(0));
        AExpr e5 = new Mull(new Addd(new CstII(1), new CstII(0)), new Addd(new Varr("x"), new CstII(0)));
        AExpr e6 = new Addd(new Mull(new CstII(5), new Varr("x")), new CstII(2));

        string fmt(AExpr a)
        {
            if (a is CstII cstI)
            {
                return cstI.Value.ToString();
            }
            else if (a is Varr var)
            {
                return var.Name;
            }
            else if (a is Addd add)
            {
                return $"({fmt(add.Expr1)} + {fmt(add.Expr2)})";
            }
            else if (a is Mull mul)
            {
                return $"({fmt(mul.Expr1)} * {fmt(mul.Expr2)})";
            }
            else if (a is Subb sub)
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
            if (a is Addd add)
            {
                var simplifiedExpr1 = simplify(add.Expr1);
                var simplifiedExpr2 = simplify(add.Expr2);

                if (simplifiedExpr1 is CstII cst1 && cst1.Value == 0)
                {
                    return simplifiedExpr2;
                }
                else if (simplifiedExpr2 is CstII cst2 && cst2.Value == 0)
                {
                    return simplifiedExpr1;
                }
                else
                {
                    return new Addd(simplifiedExpr1, simplifiedExpr2);
                }
            }
            else if (a is Subb sub)
            {
                var simplifiedExpr1 = simplify(sub.Expr1);
                var simplifiedExpr2 = simplify(sub.Expr2);

                if (simplifiedExpr2 is CstII cst2 && cst2.Value == 0)
                {
                    return simplifiedExpr1;
                }
                else if (simplifiedExpr1 == simplifiedExpr2)
                {
                    return new CstII(0);
                }
                else
                {
                    return new Subb(simplifiedExpr1, simplifiedExpr2);
                }
            }
            else if (a is Mull mul)
            {
                var simplifiedExpr1 = simplify(mul.Expr1);
                var simplifiedExpr2 = simplify(mul.Expr2);

                if (simplifiedExpr1 is CstII cst1 && cst1.Value == 1)
                {
                    return simplifiedExpr2;
                }
                else if (simplifiedExpr2 is CstII cst2 && cst2.Value == 1)
                {
                    return simplifiedExpr1;
                }
                else if (simplifiedExpr1 is CstII cst3 && cst3.Value == 0)
                {
                    return simplifiedExpr1;
                }
                else if (simplifiedExpr2 is CstII cst4 && cst4.Value == 0)
                {
                    return simplifiedExpr2;
                }
                else
                {
                    return new Mull(simplifiedExpr1, simplifiedExpr2);
                }
            }
            else
            {
                return a;
            }
        }

        AExpr diff(AExpr a)
        {
            if (a is CstII)
            {
                return new CstII(0);
            }
            else if (a is Varr)
            {
                return new CstII(1);
            }
            else if (a is Addd add)
            {
                var diffExpr1 = diff(add.Expr1);
                var diffExpr2 = diff(add.Expr2);
                return simplify(new Addd(diffExpr1, diffExpr2));
            }
            else if (a is Mull mul)
            {
                var diffExpr1 = diff(mul.Expr1);
                var diffExpr2 = diff(mul.Expr2);
                return simplify(new Mull(mul.Expr1, diffExpr2));
            }
            else if (a is Subb sub)
            {
                var diffExpr1 = diff(sub.Expr1);
                var diffExpr2 = diff(sub.Expr2);
                return simplify(new Subb(diffExpr1, diffExpr2));
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
*/
