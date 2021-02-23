// detail: https://atcoder.jp/contests/abc145/submissions/20440574
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  cout << setprecision(15);
  int n;
  cin >> n;
  using P = pair<double, double>;
  vector<P> vs(n);
  for (int i = 0; i < n; i++) cin >> vs[i].first >> vs[i].second;
  vector<int> perm(n);
  for (int i = 0; i < n; i++) perm[i] = i;
  var calc = [](P a, P b) {
    var dx = a.first - b.first;
    var dy = a.second - b.second;
    return sqrt(dx * dx + dy * dy);
  };
  int cnt = 0;
  double sum = 0;
  do
  {
    for (int i = 0; i < n - 1; i++) {
      sum += calc(vs[perm[i]], vs[perm[i + 1]]);
    }
    cnt++;
  } while (next_permutation(perm.begin(), perm.end()));
  cout << sum / cnt << endl;
}

