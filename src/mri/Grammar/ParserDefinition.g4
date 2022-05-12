parser grammar ParserDefinition;

options {
    tokenVocab = 'Generated/LexerDefinition';
    language = CSharp;
}

parse: statement*;

statement:
        var_assign              TERMINATOR
    |   var_declare             TERMINATOR
    |   expression              TERMINATOR;
    
var_assign:
        IDENTIFIER ASSIGN expression;
        
var_declare:
        IDENTIFIER;
        
constant:
        INT_VAL
    |   STR_VAL
    |   FLT_VAL;
    
func_invoke:
        IDENTIFIER arg_list;
    
arg_list:
        (expression (',' expression)*)?;    
        
expression:
        constant                    #constantExpression
    |   func_invoke                 #funcInvoke
    |   expression ADD expression   #addExpression
    |   expression DIV expression   #divExpression
    |   expression SUB expression   #subExpression
    |   expression MUL expression   #mulExpression;
        