parser grammar ParserDefinition;

options {
    tokenVocab = 'Generated/LexerDefinition';
    language = CSharp;
}

parse: block;

block: statement*;

statement:
        var_assign              TERMINATOR
    |   var_declare             TERMINATOR
    |   expression              TERMINATOR
    |   func_def;
    
var_assign:
        IDENTIFIER ASSIGN expression;
        
var_declare:
        DECLARE IDENTIFIER;
        
constant:
        INT_VAL
    |   STR_VAL
    |   FLT_VAL;
    
return_type:
    |   VOID
    |   INT
    |   STRING
    |   FLOAT;
    
func_def:
        FUNC return_type IDENTIFIER LPAREN (IDENTIFIER (',' IDENTIFIER)*)? RPAREN LBRACE block RBRACE;

func_invoke:
        IDENTIFIER LPAREN (expression (',' expression)*)? RPAREN;
        
expression:
        constant                    #constantExpression
    |   IDENTIFIER                #identifierExpression
    |   func_invoke                 #invokeFunction
    |   expression ADD expression   #addExpression
    |   expression DIV expression   #divExpression
    |   expression SUB expression   #subExpression
    |   expression MUL expression   #mulExpression;
        