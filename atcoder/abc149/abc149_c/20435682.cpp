// detail: https://atcoder.jp/contests/abc149/submissions/20435682
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int x;
  cin >> x;
  while (true) {
    for (int i = 2; i * i <= x; i++) {
      if (x % i == 0) goto invalid;
    }
    cout << x << endl;
    return 0;
  invalid:;
    x++;
  }
}
