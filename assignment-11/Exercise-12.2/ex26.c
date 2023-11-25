// micro-C example 1

void main(int n) {
  // true
  print (11 < 22);
  print (11 <= 22);
  print (11 != 22);
  print (22 > 11);
  print (22 >= 11);

  // false
  print (22 < 11);
  print (22 <= 11);
  print (22 == 11);
  print (11 > 22);
  print (11 >= 22);

  // print 33
  if (11 <= 22){
    print 33;
  }
}
