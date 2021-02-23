// detail: https://atcoder.jp/contests/code-festival-2017-qualb/submissions/20445219
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
  vector<int> d(n);
  for (int i = 0; i < n; i++) cin >> d[i];
  sort(d.begin(), d.end());
  int m;
  cin >> m;
  vector<int> t(m);
  for (int i = 0; i < m; i++) cin >> t[i];
  sort(t.begin(), t.end());
  int ind = 0;
  for (var&& elem : t) {
    while (ind < n && d[ind] < elem) ind++;
    if (d[ind] != elem) {
      cout << "NO" << endl;
      return 0;
    }
    ind++;
  }
  cout << "YES" << endl;
}
