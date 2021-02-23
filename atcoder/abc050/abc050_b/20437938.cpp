// detail: https://atcoder.jp/contests/abc050/submissions/20437938
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
  vector<int> t(n);
  for (int i = 0; i < n; i++) cin >> t[i];
  var sum = accumulate(t.begin(), t.end(), 0);
  int m;
  cin >> m;
  for (int i = 0; i < m; i++) {
    int p, x;
    cin >> p >> x;
    p--;
    cout << sum - (t[p] - x) << endl;
  }
}
