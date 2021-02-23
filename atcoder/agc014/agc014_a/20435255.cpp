// detail: https://atcoder.jp/contests/agc014/submissions/20435255
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int a, b, c;
  cin >> a >> b >> c;
  for (int i = 0; i < 100000; i++) {
    if ((a & 1) || (b & 1) || (c & 1)) {
      cout << i << endl;
      return 0;
    }
    var newa = b / 2 + c / 2;
    var newb = a / 2 + c / 2;
    var newc = a / 2 + b / 2;
    a = newa;
    b = newb;
    c = newc;
  }
  cout << -1 << endl;
}
