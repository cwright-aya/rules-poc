using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2;

public class Rule
{
    public Operator Operator { get; set; }
    public string Expression { get; set; }
    public string ExpressionString()
    {
        var operatorString = Operator switch
        {
            Operator.AND => "&&",
            Operator.OR => "||",
            _ => ""
        };
        return $"{operatorString} {Expression}";
    }
}
