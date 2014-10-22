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
					var node = Recognize_expression (tokenstream);
					Recognize_end_of_expression (tokenstream, node,
						onSuccess);
				},
				onError);
		}
			
		private Node Recognize_expression(List<Token> tokenstream) {
			var node = Recognize_value (tokenstream);
			return Recognize_expression_tail (tokenstream, node);
		}

		private Node Recognize_expression_tail(List<Token> tokenstream, Node node) {
			if (tokenstream.Count == 0)	return node;

			var op = Recognize_operator (tokenstream);
			op.Left = node;
			op.Right = Recognize_value (tokenstream);

			return Recognize_expression_tail (tokenstream, op);
		}

		private Node Recognize_value(List<Token> tokenstream) {
			var operand = tokenstream.FirstOrDefault () as OperandToken;
			if (operand != null) {
				tokenstream.RemoveAt (0);
				return new OperandNode{ Value = operand.Value };
			}
			else
				throw new InvalidOperationException ("Missing value!");
		}

		private Node Recognize_operator(List<Token> tokenstream) {
			var op = tokenstream.FirstOrDefault () as OperatorToken;
			if (op != null) {
				tokenstream.RemoveAt (0);
				return new OperatorNode{ Op = op.Op };
			}
			else
				throw new InvalidOperationException ("Missing operator!");
		}

		private void Recognize_end_of_expression(List<Token> tokenstream, Node root, Action<AST> onSuccess) {
			if (tokenstream.Count == 0)
				onSuccess (new AST{ Root = root });
			else
				throw new InvalidOperationException ("Unexpected end of expression!");
		}
	}
}
