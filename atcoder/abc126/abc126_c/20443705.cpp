// detail: https://atcoder.jp/contests/abc126/submissions/20443705
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  cout << setprecision(15);
  int n, k;
  cin >> n >> k;
  double res = 0;
  for (int i = 1; i <= n; i++) {
    double prob = 1.0 / n;
    int num = i;
    while (num < k) {
      num *= 2;
      prob /= 2;
    }
    res += prob;
  }
  cout << res << endl;
}
