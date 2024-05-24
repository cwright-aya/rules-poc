using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2;

public interface SourceModel<TTarget>
{
    TTarget TransformToTarget();
}

public class EntityRuleSet<TSource, TTarget> where TSource : SourceModel<TTarget>
{
    public string SourceKey { get; set; }
    public List<RuleGroup> RuleGroups { get; set; }


    public List<TTarget> Execute(IEnumerable<TSource> data)
    {
        var returnSet = new Dictionary<object, TTarget>();
        var property = typeof(TSource).GetProperty(SourceKey);
        foreach (var item in data)
        {

            returnSet.Add(property.GetValue(item), item.TransformToTarget());
        }
        RuleGroups.ForEach(ruleGroup =>
        {
            var keys = ruleGroup.GetPassingIds(SourceKey, data, returnSet);
            ruleGroup.ExecuteActions(ruleGroup.RuleActions, keys, returnSet);
        });

        return returnSet.Values.ToList();
    }
}
