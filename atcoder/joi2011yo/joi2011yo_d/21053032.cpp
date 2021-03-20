// detail: https://atcoder.jp/contests/joi2011yo/submissions/21053032
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int n;
vector<int> a;

using P = pair<int, int>;
map<P, ll> mp;

ll dfs(int ind, int sum) {
  if (sum < 0 || 20 < sum) return 0;
  if (ind == n - 1) return sum == a[ind] ? 1 : 0;
  if (mp.count(P(ind, sum))) return mp[P(ind, sum)];
  return mp[P(ind, sum)] = dfs(ind + 1, sum + a[ind]) + dfs(ind + 1, sum - a[ind]);
}

int main() {
  cin >> n;
  a = vector<int>(n);
  for (var&& elem : a) cin >> elem;
  cout << dfs(1, a[0]) << endl;
}
