package com.epam.bsp.stack;

import java.util.Stack;

public class Solution {

    /**
     * Returns true if a given string is valid parentheses expression.
     *
     * @param expression input string for validation.
     * @return whether a given string is valid parentheses expression.
     */
    public static boolean isValidParentheses(String expression) {
        Stack<Character> stack = new Stack<>();

        for (char c : expression.toCharArray()) {
            if (c == '(' || c == '{' || c == '[') {
                stack.push(c);
            } else {
                if (stack.isEmpty()) return false;
                char open = stack.pop();
                if ((c == ')' && open != '(') ||
                    (c == '}' && open != '{') ||
                    (c == ']' && open != '[')) {
                    return false;
                }
            }
        }

        return stack.isEmpty();
    }

    /**
     * Returns the evaluation result of a given list of RPN tokens.
     *
     * @param rpnTokens a list of RPN tokens
     * @return the evaluation result
     */
    public static int evaluateRpnTokens(String[] rpnTokens) {
        Stack<Integer> stack = new Stack<>();

        for (String token : rpnTokens) {
            switch (token) {
                case "+":
                    stack.push(stack.pop() + stack.pop());
                    break;
                case "-": {
                    int b = stack.pop();
                    int a = stack.pop();
                    stack.push(a - b);
                    break;
                }
                case "*":
                    stack.push(stack.pop() * stack.pop());
                    break;
                case "/": {
                    int b = stack.pop();
                    int a = stack.pop();
                    stack.push(a / b);
                    break;
                }
                default:
                    stack.push(Integer.parseInt(token));
            }
        }

        return stack.pop();
    }
}
