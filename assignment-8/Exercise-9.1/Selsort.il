
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.1
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Selsort
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module Selsort.exe
// MVID: {D35CA8DA-971E-4278-9FEE-7E07D1DD2DA8}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x030D0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Selsort
       extends [mscorlib]System.Object
{
  .field public static initonly class [mscorlib]System.Random rnd
  .method public hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       87 (0x57)
    .maxstack  4
    .locals init (int32 V_0,
             int32[] V_1,
             int32 V_2,
             int32 V_3)
    IL_0000:  ldc.i4.s   10
    IL_0002:  stloc.0
    IL_0003:  ldloc.0
    IL_0004:  newarr     [mscorlib]System.Int32
    IL_0009:  stloc.1
    IL_000a:  ldc.i4.0
    IL_000b:  stloc.2
    IL_000c:  br.s       IL_0024

    IL_000e:  ldloc.1
    IL_000f:  ldloc.2
    IL_0010:  ldsfld     class [mscorlib]System.Random Selsort::rnd
    IL_0015:  ldc.i4     0xf4240
    IL_001a:  callvirt   instance int32 [mscorlib]System.Random::Next(int32)
    IL_001f:  stelem.i4
    IL_0020:  ldloc.2
    IL_0021:  ldc.i4.1
    IL_0022:  add
    IL_0023:  stloc.2
    IL_0024:  ldloc.2
    IL_0025:  ldloc.0
    IL_0026:  blt.s      IL_000e

    IL_0028:  ldloc.1
    IL_0029:  call       void Selsort::SelectionSort(int32[])
    IL_002e:  ldc.i4.0
    IL_002f:  stloc.3
    IL_0030:  br.s       IL_004d

    IL_0032:  ldloc.1
    IL_0033:  ldloc.3
    IL_0034:  ldelem.i4
    IL_0035:  box        [mscorlib]System.Int32
    IL_003a:  ldstr      " "
    IL_003f:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_0044:  call       void [mscorlib]System.Console::Write(string)
    IL_0049:  ldloc.3
    IL_004a:  ldc.i4.1
    IL_004b:  add
    IL_004c:  stloc.3
    IL_004d:  ldloc.3
    IL_004e:  ldloc.0
    IL_004f:  blt.s      IL_0032

    IL_0051:  call       void [mscorlib]System.Console::WriteLine()
    IL_0056:  ret
  } // end of method Selsort::Main

.method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  { 
    // Code size       57 (0x39)
    .maxstack  4
    .locals init (int32 V_0,            // Loop counter (outer loop)
             int32 V_1,                 // Store index of min element
             int32 V_2,                 // Loop counter (inner loop)
             int32 V_3)                 // temp store for swapping   
    IL_0000:  ldc.i4.0                  // initialize V_0 w/ 0
    IL_0001:  stloc.0                   // Store value on V_0 stack
    IL_0002:  br.s       IL_0032        // Beginning of outer loop
    
    // Runs the outer loop
    IL_0004:  ldloc.0                   // loads V_0 val to stack
    IL_0005:  stloc.1                   // store V_1 value, tracking index of min element
    IL_0006:  ldloc.0                   
    IL_0007:  ldc.i4.1                  // Loads 1 onto the stack
    IL_0008:  add                       // adds the top two values on the stack (then push)
    IL_0009:  stloc.2                   // store in V_2 (inner loop) 
    IL_000a:  br.s       IL_001a        // beginning of inner loop
    
    IL_000c:  ldarg.0                   // loads arr onto stack 
    IL_000d:  ldloc.2                   // loads value V_2 onto stack
    IL_000e:  ldelem.i4                 // load the corresponding value at index V_2 in "arr"    
    IL_000f:  ldarg.0                   // loads array onto the stack
    IL_0010:  ldloc.1                   // V_1 onto stack
    IL_0011:  ldelem.i4                 // load the corresponding value at index V_2 in "arr"
    IL_0012:  bge.s      IL_0016        // branches if >= IL_0016

    IL_0014:  ldloc.2                   // Loads V_2 onto stack
    IL_0015:  stloc.1                   // Pops curr val (min element) then store index in V_1
    IL_0016:  ldloc.2                   
    IL_0017:  ldc.i4.1                  // Loads 1 onto stack
    IL_0018:  add                       // adds the top two values on the stack (then push)
    IL_0019:  stloc.2                   // update v_2 for next iteration of loop
    IL_001a:  ldloc.2                   // load v_2 value
    IL_001b:  ldarg.0                   // load 'arr' onto stack
    IL_001c:  ldlen                     // get 'arr' length
    IL_001d:  conv.i4                   // conv length to int32
    IL_001e:  blt.s      IL_000c        // branch to inner loop beginning if V_2 < arrlen

    IL_0020:  ldarg.0                   // Load 'arr' to stack
    IL_0021:  ldloc.0                   // Load val of V_0 to stack
    IL_0022:  ldelem.i4                 // Load int at V_0 index from 'arr'
    IL_0023:  stloc.3                   // store val in V_3, temp store for swapping elements
    IL_0024:  ldarg.0                   // Load 'arr' to stack    
    IL_0025:  ldloc.0                   // Load V_0 val onto stack
    IL_0026:  ldarg.0                   // Load V_1 onto stack
    IL_0027:  ldloc.1                   // Load V_1 val onto stack
    IL_0028:  ldelem.i4                 // Load int at index V_1 from 'arr'
    IL_0029:  stelem.i4                 // Store val at index V_1 of 'arr'
    IL_002a:  ldarg.0                   // Load 'arr' onto stack
    IL_002b:  ldloc.1                   // Load val v_1 onto stack
    IL_002c:  ldloc.3                   // Load val from V_3 (orig val at index V_0)    
    IL_002d:  stelem.i4                 // Store the val in the element at index V_1 of 'arr'
    IL_002e:  ldloc.0                   // Load V_0 onto stack
    IL_002f:  ldc.i4.1                  // Load '1' onto the stack
    IL_0030:  add                       // adds the top two values on the stack (then push)
    IL_0031:  stloc.0                   // Update V_0 for next iter of outer loop, pop curr stack val
    IL_0032:  ldloc.0                   // Load V_0 onto stack
    IL_0033:  ldarg.0                   // Load 'arr onto stack
    IL_0034:  ldlen                     // get arr length
    IL_0035:  conv.i4                   // conv length to int32
    IL_0036:  blt.s      IL_0004        // branch to outer loop beginning if V_2 < arrlen

    IL_0038:  ret                       // Return method
  } // end of method Selsort::SelectionSort

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Selsort::.ctor

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  8
    IL_0000:  newobj     instance void [mscorlib]System.Random::.ctor()
    IL_0005:  stsfld     class [mscorlib]System.Random Selsort::rnd
    IL_000a:  ret
  } // end of method Selsort::.cctor

} // end of class Selsort


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
