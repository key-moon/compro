// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2332/judge/4896349/C++14
#include <bits/stdc++.h>

#define var auto
#define ll long long

using namespace std;

int main() {
	int n;
	cin >> n;
	vector<int> a(n);
	for (size_t i = 0; i < n; i++)
	{
		cin >> a[i];
	}
	vector<int> time(n, INT_MAX / 2);
	deque<int> queue{};
	queue.push_back(0);
	time[0] = 0;
	while (!queue.empty())
	{
		var elem = queue.front(); queue.pop_front();
		if (a[elem] == 0) {
			var nextTime = time[elem] + 1;
			var limit = min(elem + 6, n - 1);
			for (int next = elem + 1; next <= limit; next++)
			{
				if (nextTime >= time[next]) continue;
				time[next] = nextTime;
				queue.push_back(next);
			}
		}
		else {
			var nextTime = time[elem];

			int next = elem + a[elem];
			//if (next < 0 || n <= next)
			if (nextTime >= time[next]) continue;
			time[next] = time[elem];
			queue.push_front(next);
		}
	}
	cout << time[n - 1] << endl;
}


