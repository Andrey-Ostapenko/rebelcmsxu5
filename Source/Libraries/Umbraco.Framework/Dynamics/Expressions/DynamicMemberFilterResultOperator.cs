namespace Umbraco.Framework.Dynamics.Expressions
{
    using System;
    using System.Linq.Expressions;
    using Remotion.Linq.Clauses;
    using Umbraco.Framework.Expressions.Remotion;
    using Umbraco.Framework.Linq.QueryModel;

    public class DynamicMemberFilterResultOperator : AbstractExtensionResultOperator
    {
        public DynamicMemberFilterResultOperator(Expression parameter)
            : base(parameter)
        {
        }

        #region Overrides of AbstractExtensionResultOperator

        public override void ModifyQueryDescription(QueryDescriptionBuilder queryDescription, Type resultType)
        {
            var constant = FirstParameter as ConstantExpression;
            //queryDescription.From.RequiredEntityIds = (IEnumerable<HiveId>)(constant.Value);
        }

        public override string Name
        {
            get
            {
                return "DynamicMemberFilter";
            }
        }

        public override ResultOperatorBase Clone(CloneContext cloneContext)
        {
            return new DynamicMemberFilterResultOperator(FirstParameter);
        }

        #endregion
    }
}