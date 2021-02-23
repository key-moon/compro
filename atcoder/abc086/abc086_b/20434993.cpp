// detail: https://atcoder.jp/contests/abc086/submissions/20434993
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int a, b;
  cin >> a >> b;
  int dig = 1;
  if (b < 10) dig = 10;
  else if (b < 100) dig = 100;
  else if (b < 1000) dig = 1000;
  a = a * dig + b;
  for (int i = 1; i * i <= a; i++) {
    if (i * i == a) {
      cout << "Yes" << endl;
      return 0;
    }
  }
  cout << "No" << endl;
  return 0;
}
