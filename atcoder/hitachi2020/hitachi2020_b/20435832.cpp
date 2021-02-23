// detail: https://atcoder.jp/contests/hitachi2020/submissions/20435832
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int A, B, m;
  cin >> A >> B >> m;
  vector<int> a(A);
  vector<int> b(B);
  for (int i = 0; i < A; i++) cin >> a[i];
  for (int i = 0; i < B; i++) cin >> b[i];
  var res = *min_element(a.begin(), a.end()) + *min_element(b.begin(), b.end());
  for (int i = 0; i < m; i++) {
    int x, y, c;
    cin >> x >> y >> c;
    chmin(res, a[x - 1] + b[y - 1] - c);
  }
  cout << res << endl;
}
