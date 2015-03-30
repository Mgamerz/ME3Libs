﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME3Script.Language.Tree
{
    public class Class : ASTNode
    {
        public String Name;
        public Variable Parent;
        public Variable OuterClass;
        public List<Specifier> Specifiers;
        public List<VariableDeclaration> Variables;
        public List<Function> Functions;
        public List<State> States;

        public Class(String name, List<Specifier> specs, 
            List<VariableDeclaration> vars, List<Function> funcs,
            List<State> states, Variable parent, Variable outer)
            : base(ASTNodeType.Class)
        {
            Name = name;
            Parent = parent;
            OuterClass = outer;
            Specifiers = specs;
            Variables = vars;
            Functions = funcs;
            States = states;
        }
    }
}