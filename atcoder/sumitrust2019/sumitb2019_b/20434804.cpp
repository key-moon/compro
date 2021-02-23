// detail: https://atcoder.jp/contests/sumitrust2019/submissions/20434804
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  for (int i = 0; i <= n; i++) {
    if (n == i * 108 / 100) {
      cout << i << endl;
      return 0;
    }
  }
  cout << ":(" << endl;

}
