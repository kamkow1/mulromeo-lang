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
    |   add_element             TERMINATOR
    |   flush_memory            TERMINATOR
    |   func_def
    |   range_loop;
    
var_assign:
        IDENTIFIER ASSIGN expression;
        
var_declare:
        DECLARE IDENTIFIER;
        
constant:
        INT_VAL
    |   STR_VAL
    |   FLT_VAL;

html_output_type:
        VIDEO
    |   AUDIO
    |   IMAGE;
  
add_element:
        OUTPUT_HTML html_output_type (expression (',' expression)*)?;
    
range_loop:
        LOOP expression PIPE expression ARROW IDENTIFIER LBRACE block RBRACE;
    
flush_memory:
        AT FLUSH PIPE (expression (',' expression)*)? PIPE;
    
return_type:
    |   VOID
    |   INT
    |   STRING
    |   FLOAT;
    
func_def:
        FUNC return_type IDENTIFIER LPAREN (IDENTIFIER (',' IDENTIFIER)*)? RPAREN LBRACE block RBRACE;

func_invoke:
        IDENTIFIER (expression (',' expression)*)?;
    
reference:
        AMP IDENTIFIER;  
        
array:
        LSQBR (expression (',' expression)*)? RSQBR;
        
array_get_elem:
        IDENTIFIER ARROW expression;
      
expression:
        constant                    #constantExpression
    |   IDENTIFIER                  #identifierExpression
    |   reference                   #referenceExpression
    |   array                       #arrayExpression
    |   array_get_elem              #arrayGetElemtExpression
    |   LPAREN expression RPAREN    #emphExpression
    |   func_invoke                 #invokeFunction
    |   expression ADD expression   #addExpression
    |   expression DIV expression   #divExpression
    |   expression SUB expression   #subExpression
    |   expression MUL expression   #mulExpression;
        