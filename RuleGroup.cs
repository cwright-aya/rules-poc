using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2;

public class RuleGroup
{
    public List<Rule> Rules { get; set; }
    public List<RuleAction> RuleActions { get; set; }
    public string ExpressionString()
    {
        return String.Join(" ", Rules.Select(rule => rule.ExpressionString()));
    }

    public List<object> GetPassingIds<TSource, TTarget>(string sourceKey, IEnumerable<TSource> data, Dictionary<Object, TTarget> results)
    {
        var property = typeof(TSource).GetProperty(sourceKey);
        return data.AsQueryable().Where(ExpressionString()).Select(item => property.GetValue(item)).ToList();
    }

    public void ExecuteActions<TTarget>(List<RuleAction> actions, List<object> keys, Dictionary<object, TTarget> returnSet)
    {

        actions.ForEach(action =>
        {
            var property = typeof(TTarget).GetProperty(action.SetProperty);
            keys.ForEach(key => property.SetValue(returnSet[key], action.Value));
        });
    }
}
