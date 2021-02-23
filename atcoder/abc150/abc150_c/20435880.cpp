// detail: https://atcoder.jp/contests/abc150/submissions/20435880
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
  vector<int> p(n);
  for (int i = 0; i < n; i++) cin >> p[i];
  vector<int> q(n);
  for (int i = 0; i < n; i++) cin >> q[i];
  vector<int> a(n);
  for (int i = 0; i < n; i++) a[i] = i + 1;
  int cnt = 0;
  int pi = 0;
  int qi = 0;
  do
  {
    if (a == p) pi = cnt;
    if (a == q) qi = cnt;
    cnt++;
  } while (next_permutation(a.begin(), a.end()));
  cout << abs(pi - qi) << endl;
}
