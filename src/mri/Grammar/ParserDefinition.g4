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
        
constant:
        INT_VAL
    |   STR_VAL
    |   FLT_VAL;
        
expression:
        constant;
        