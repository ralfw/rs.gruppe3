using System;
using System.Linq;
using System.Collections.Generic;

namespace expressioncalculator
{
	class Parser {
		public void Parse(Token[] tokens, Action<AST> onSuccess, Action<string> onError) {
			Errorhandling.Try (
				() => {
					var tokenstream = new List<Token> (tokens);
					var ast = Recognize_expression (tokenstream);
					Recognize_end_of_expression (tokenstream, ast,
						onSuccess);
				},
				onError);
		}
			
		private AST Recognize_expression(List<Token> tokenstream) {
			var ast = new AST{ Ops = new List<Operators>(), Operands = new List<int>() };
			Recognize_value (tokenstream, ast);
			Recognize_expression_tail (tokenstream, ast);
			return ast;
		}

		private void Recognize_expression_tail(List<Token> tokenstream, AST ast) {
			if (tokenstream.Count == 0)	return;

			Recognize_operator (tokenstream, ast);
			Recognize_value (tokenstream, ast);

			Recognize_expression_tail (tokenstream, ast);
		}

		private void Recognize_value(List<Token> tokenstream, AST ast) {
			var operand = tokenstream.FirstOrDefault () as OperandToken;
			if (operand != null) {
				tokenstream.RemoveAt (0);
				ast.Operands.Add (operand.Value);
			}
			else
				throw new InvalidOperationException ("Missing value!");
		}

		private void Recognize_operator(List<Token> tokenstream, AST ast) {
			var op = tokenstream.FirstOrDefault () as OperatorToken;
			if (op != null) {
				tokenstream.RemoveAt (0);
				ast.Ops.Add (op.Op);
			}
			else
				throw new InvalidOperationException ("Missing operator!");
		}

		private void Recognize_end_of_expression(List<Token> tokenstream, AST ast, Action<AST> onSuccess) {
			if (tokenstream.Count == 0)
				onSuccess (ast);
			else
				throw new InvalidOperationException ("Unexpected end of expression!");
		}
	}
}
