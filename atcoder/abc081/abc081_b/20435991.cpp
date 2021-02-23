// detail: https://atcoder.jp/contests/abc081/submissions/20435991
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
  int res = INT_MAX;
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    int cnt = 0;
    while (a % 2 == 0) {
      a /= 2;
      cnt++;
    }
    chmin(res, cnt);
  }
  cout << res << endl;
}
