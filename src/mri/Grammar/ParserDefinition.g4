parser grammar ParserDefinition;

options {
    tokenVocab = 'Generated/LexerDefinition';
    language = CSharp;
}

parse: statement*;

statement:
        var_assign              TERMINATOR
    |   var_declare             TERMINATOR;
    
var_assign:
        IDENTIFIER ASSIGN expression;
        
var_declare:
        IDENTIFIER;
        

        
expression:
        STR_VAL                 #stringExpression
    |   INT_VAL                 #intExpression
    |   FLT_VAL                 #floatExpression;