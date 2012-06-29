namespace Umbraco.Framework.Linq.CriteriaGeneration.StructureMetadata
{
    using System.Linq.Expressions;

    using Umbraco.Framework.Linq.CriteriaGeneration.Expressions;

    /// <summary>
    /// When implemented in a derived class, provides a mechanism to assess certain types of expression and determine whether
    /// they are supported by the provider. For example, implementors of this class may advertise that the expression for the
    /// <see cref="System.String.EndsWith(string)"/> is supported.
    /// </summary>
    /// <remarks></remarks>
    public abstract class AbstractQueryStructureBinder
    {
        /// <summary>
        /// Determines whether the expression represents a supported method call.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <remarks></remarks>
        public abstract BindingSignatureSupport IsSupportedMethod(MethodCallExpression expression);

        /// <summary>
        /// Determines whether the expression represents a supported member access call, and if so the type of support is described by the returned <see cref="BindingSignatureSupport"/>.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <remarks></remarks>
        public abstract BindingSignatureSupport IsSupportedMember(MemberExpression expression);

        /// <summary>
        /// Creates a <see cref="FieldSelectorExpression"/> from a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="reportedSignatureSupport">A component outlining the supported expression structure of this provider.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual FieldSelectorExpression CreateFieldSelector(MethodCallExpression expression, BindingSignatureSupport reportedSignatureSupport)
        {
            return CreateFieldSelector(expression.Method.Name, null, reportedSignatureSupport);
        }

        /// <summary>
        /// Creates a <see cref="FieldSelectorExpression"/> from a <see cref="MemberExpression"/>.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="reportedSignatureSupport">A component outlining the supported expression structure of this provider.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual FieldSelectorExpression CreateFieldSelector(MemberExpression expression, BindingSignatureSupport reportedSignatureSupport)
        {
            var memberParent = expression.Expression as MemberExpression;
            if (memberParent != null)
                return CreateFieldSelector(memberParent.Member.Name, expression.Member.Name, reportedSignatureSupport);

            return CreateFieldSelector(expression.Member.Name, null, reportedSignatureSupport);
        }

        /// <summary>
        /// Creates the field selector.
        /// </summary>
        /// <param name="fieldame">The fieldame.</param>
        /// <param name="innerFieldName">Name of the inner field.</param>
        /// <param name="reportedSignatureSupport">The reported signature support.</param>
        /// <returns></returns>
        public virtual FieldSelectorExpression CreateFieldSelector(string fieldame, string innerFieldName, BindingSignatureSupport reportedSignatureSupport)
        {
            if(!string.IsNullOrWhiteSpace(innerFieldName))
                return  new FieldSelectorExpression(innerFieldName);

            return new FieldSelectorExpression(fieldame);
        }

        public virtual SchemaSelectorExpression CreateSchemaSelector(MethodCallExpression expression, BindingSignatureSupport reportedSignatureSupport)
        {
            return new SchemaSelectorExpression(expression.Method.Name);
        }

        public virtual SchemaSelectorExpression CreateSchemaSelector(MemberExpression expression, BindingSignatureSupport reportedSignatureSupport)
        {
            return new SchemaSelectorExpression(expression.Member.Name);
        }

        public virtual SchemaValueExpression CreateSchemaValueExpression(MethodCallExpression expression, BindingSignatureSupport reportedSignatureSupport)
        {
            return new SchemaValueExpression(reportedSignatureSupport.NodeType, ExpressionHelper.GetFirstValueFromArguments(expression.Arguments));
        }

        /// <summary>
        /// Creates a <see cref="FieldValueExpression"/> from a <see cref="MethodCallExpression"/>.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="reportedSignatureSupport">A component outlining the supported expression structure of this provider.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual FieldValueExpression CreateFieldValueExpression(MethodCallExpression expression, BindingSignatureSupport reportedSignatureSupport)
        {
            return new FieldValueExpression(reportedSignatureSupport.NodeType, ExpressionHelper.GetFirstValueFromArguments(expression.Arguments));
        }
    }
}