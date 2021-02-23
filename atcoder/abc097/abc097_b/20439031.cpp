// detail: https://atcoder.jp/contests/abc097/submissions/20439031
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
  int res = 1;
  for (int b = 2; b <= 1000; b++) {
    int n = b * b;
    while (n <= x) {
      chmax(res, n);
      n *= b;
    }
  }
  cout << res << endl;
}
