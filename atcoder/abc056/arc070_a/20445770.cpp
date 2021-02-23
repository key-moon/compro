// detail: https://atcoder.jp/contests/abc056/submissions/20445770
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll x;
  cin >> x;
  for (int i = 1; ; i++) {
    x -= i;
    if (x <= 0) {
      cout << i << endl;
      return 0;
    }
  }
}
