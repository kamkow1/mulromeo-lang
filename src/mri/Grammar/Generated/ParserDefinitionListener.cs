//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/kamil/Desktop/mulromeo-lang/src/mri/Grammar\ParserDefinition.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="ParserDefinition"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public interface IParserDefinitionListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParse([NotNull] ParserDefinition.ParseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParse([NotNull] ParserDefinition.ParseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] ParserDefinition.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] ParserDefinition.BlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] ParserDefinition.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] ParserDefinition.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.var_assign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVar_assign([NotNull] ParserDefinition.Var_assignContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.var_assign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVar_assign([NotNull] ParserDefinition.Var_assignContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.var_declare"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVar_declare([NotNull] ParserDefinition.Var_declareContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.var_declare"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVar_declare([NotNull] ParserDefinition.Var_declareContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstant([NotNull] ParserDefinition.ConstantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstant([NotNull] ParserDefinition.ConstantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.html_output_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHtml_output_type([NotNull] ParserDefinition.Html_output_typeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.html_output_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHtml_output_type([NotNull] ParserDefinition.Html_output_typeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.add_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdd_element([NotNull] ParserDefinition.Add_elementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.add_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdd_element([NotNull] ParserDefinition.Add_elementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.range_loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRange_loop([NotNull] ParserDefinition.Range_loopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.range_loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRange_loop([NotNull] ParserDefinition.Range_loopContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.return_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturn_type([NotNull] ParserDefinition.Return_typeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.return_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturn_type([NotNull] ParserDefinition.Return_typeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.func_def"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunc_def([NotNull] ParserDefinition.Func_defContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.func_def"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunc_def([NotNull] ParserDefinition.Func_defContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.func_invoke"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunc_invoke([NotNull] ParserDefinition.Func_invokeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.func_invoke"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunc_invoke([NotNull] ParserDefinition.Func_invokeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParserDefinition.reference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReference([NotNull] ParserDefinition.ReferenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParserDefinition.reference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReference([NotNull] ParserDefinition.ReferenceContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstantExpression([NotNull] ParserDefinition.ConstantExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstantExpression([NotNull] ParserDefinition.ConstantExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>addExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddExpression([NotNull] ParserDefinition.AddExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>addExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddExpression([NotNull] ParserDefinition.AddExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>referenceExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReferenceExpression([NotNull] ParserDefinition.ReferenceExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>referenceExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReferenceExpression([NotNull] ParserDefinition.ReferenceExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierExpression([NotNull] ParserDefinition.IdentifierExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierExpression([NotNull] ParserDefinition.IdentifierExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>divExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDivExpression([NotNull] ParserDefinition.DivExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>divExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDivExpression([NotNull] ParserDefinition.DivExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>invokeFunction</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInvokeFunction([NotNull] ParserDefinition.InvokeFunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>invokeFunction</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInvokeFunction([NotNull] ParserDefinition.InvokeFunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>subExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubExpression([NotNull] ParserDefinition.SubExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>subExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubExpression([NotNull] ParserDefinition.SubExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>mulExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMulExpression([NotNull] ParserDefinition.MulExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>mulExpression</c>
	/// labeled alternative in <see cref="ParserDefinition.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMulExpression([NotNull] ParserDefinition.MulExpressionContext context);
}
