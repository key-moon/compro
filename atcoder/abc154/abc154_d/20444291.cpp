// detail: https://atcoder.jp/contests/abc154/submissions/20444291
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  cout << setprecision(15) << fixed;
  int n, k;
  cin >> n >> k;
  vector<int> p(n);
  for (int i = 0; i < n; i++) cin >> p[i];
  double prob = 0;
  for (int i = 0; i < k; i++) {
    prob += p[i] / 2.0 + 0.5;
  }
  var mx = prob;
  for (int i = k; i < n; i++) {
    prob -= p[i - k] / 2.0 + 0.5;
    prob += p[i] / 2.0 + 0.5;
    chmax(mx, prob);
  }
  cout << mx << endl;
}
