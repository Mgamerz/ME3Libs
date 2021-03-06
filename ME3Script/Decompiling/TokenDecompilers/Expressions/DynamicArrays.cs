﻿using ME3Script.Analysis.Visitors;
using ME3Script.Language.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME3Script.Decompiling
{
    public partial class ME3ByteCodeDecompiler
    {
        public Expression DecompileDynArrLength()
        {
            PopByte();
            var arr = DecompileExpression();
            if (arr == null)
                return null;

            StartPositions.Pop();
            // TODO: ugly solution, should be reworked once dynarrays are in the AST.
            return new CompositeSymbolRef(arr, new SymbolReference(null, null, null, "Length"), null, null);
        }

        public Expression DecompileDynArrFunction(String name, bool secondArg = false, bool withoutMemOffs = false, bool withoutTrailingByte = false)
        {
            PopByte();
            var arr = DecompileExpression();
            if (arr == null)
                return null;

            if (!withoutMemOffs)
                ReadInt16(); // MemSize

            var args = new List<Expression>();
            if (secondArg)
            {
                var prop = DecompileExpression();
                if (prop == null)
                    return null;
                args.Add(prop);
            }

            var value = DecompileExpression();
            if (value == null)
                return null;
            args.Add(value);

            if (!withoutTrailingByte)
                PopByte(); // EndFuncParms

            var builder = new CodeBuilderVisitor(); // what a wonderful hack, TODO.
            arr.AcceptVisitor(builder);

            StartPositions.Pop();
            // TODO: ugly solution, should be reworked once dynarrays are in the AST.
            return new FunctionCall(new SymbolReference(null, null, null, builder.GetCodeString() + "." + name), args, null, null);
        }
    }
}
